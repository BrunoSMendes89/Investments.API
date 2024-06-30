using Domain.Enums;
using MediatR;

namespace Service.Models
{
    public class PostProductRequest : IRequest<string>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public DateTime DueDate { get; set; }
    }
}
