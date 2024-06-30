using Domain.Enums;
using MediatR;

namespace Service.Models
{
    public class PutBalanceRequest : IRequest<string>
    {
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
    }
}
