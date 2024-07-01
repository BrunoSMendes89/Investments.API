using Domain.Enums;
using MediatR;

namespace Service.Models
{
    public class BuyProductByCustomerRequest : IRequest<string>
    {
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
    }
}
