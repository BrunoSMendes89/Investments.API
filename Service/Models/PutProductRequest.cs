using Domain.Enums;
using MediatR;

namespace Service.Models
{
    public class PutProductRequest : IRequest<string>
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public DateTime DueDate { get; set; }
    }
}
