using Domain.Models;
using MediatR;

namespace Service.Models
{
    public class GetTransactionsRequest : IRequest<List<TransactionModel>>
    {
        public int CustomerId { get; set; }
    }
}
