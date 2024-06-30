using Domain.Enums;

namespace Domain.Entities
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductTypeEnum ProductType { get; set; }
        public DateTime DueDate { get; set; }
    }
}
