using Domain.Enums;
using Domain.Models;
using MediatR;

namespace Service.Models
{
    public class PutBalanceRequest : IRequest<CustomerModel>
    {
        public int CustomerId { get; set; }
        public double Amount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
    }
}
