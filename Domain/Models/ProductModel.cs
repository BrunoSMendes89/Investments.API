using Domain.Enums;

namespace Domain.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public DateTime DueDate { get; set; }
        public bool Active { get; set; }
    }
}
