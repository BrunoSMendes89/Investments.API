using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Service.Models;

namespace Service.Handlers
{
    public class GetTransactionsHandler : IRequestHandler<GetTransactionsRequest, List<TransactionModel>>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;

        public GetTransactionsHandler(MySqlContext sqlContext, IMapper mapper)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
        }
        public async Task<List<TransactionModel>> Handle(GetTransactionsRequest request, CancellationToken cancellationToken)
        {
            var transactions = await _sqlContext.Customer.Include(t => t.Transactions).FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId);
            if (transactions == null)
                throw new PreconditionFailedException();
            var response = transactions.Transactions.Select(t => new TransactionModel { TransactionId = t.TransactionId, Amount = t.Amount, TransactionType = t.TransactionType, 
                                                                                        Description = t.Description, Date = t.Date, CustomerId = t.CustomerId, ProductId = t.ProductId})
                                                                                        .ToList();
            return response;
        }
    }
}
