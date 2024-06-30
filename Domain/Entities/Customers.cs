namespace Domain.Entities
{
    public class Customers
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public int AccountNumber { get; set; }
        public List<Products> Products { get; set; }
    }
}
