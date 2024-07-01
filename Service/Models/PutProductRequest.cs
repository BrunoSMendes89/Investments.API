using Domain.Enums;
using Domain.Models;
using MediatR;

namespace Service.Models
{
    public class PutProductRequest : IRequest<ProductModel>
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public DateTime DueDate { get; set; }
    }
}
