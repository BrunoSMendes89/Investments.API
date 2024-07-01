using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Service.Helpers;
using Service.Models;

namespace Service.Handlers
{
    public class PutBalanceHandler : IRequestHandler<PutBalanceRequest, string>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;

        public PutBalanceHandler(MySqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }

        public async Task<string> Handle(PutBalanceRequest request, CancellationToken cancellationToken)
        {
            var query = _sqlContext.Customer.AsQueryable();
            var customer = await query.Include(s => s.Transactions).FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId, cancellationToken);            
            if (customer is null)
                throw new PreconditionFailedException();
            HelpersClass.UpdateBalance(customer, request.Amount, request.TransactionType);
            _sqlContext.Entry(customer);
            await _sqlContext.SaveChangesAsync(cancellationToken);
            return HelpersClass.UpdatedSuccess(customer.CustomerId);
        }        
    }
}
