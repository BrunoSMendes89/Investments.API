using AutoMapper;
using Domain.Entities;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Service.Helpers;
using Service.Models;

namespace Service.Handlers
{
    public class PutBalanceHandler : IRequestHandler<PutBalanceRequest, CustomerModel>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;

        public PutBalanceHandler(MySqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }

        public async Task<CustomerModel> Handle(PutBalanceRequest request, CancellationToken cancellationToken)
        {
            if (request.TransactionType != Domain.Enums.TransactionTypeEnum.Credit && request.TransactionType != Domain.Enums.TransactionTypeEnum.Debit)
                throw new PreconditionFailedException("Transaction Type not Allowed");

            var query = _sqlContext.Customer.AsQueryable();
            var customer = await query.Include(s => s.Transactions).FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId, cancellationToken);            
            if (customer is null)
                throw new PreconditionFailedException();
            HelpersClass.UpdateBalance(customer, request.Amount, request.TransactionType);
            _sqlContext.Entry(customer);
            await _sqlContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CustomerModel>(customer);
        }        
    }
}
