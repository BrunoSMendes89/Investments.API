using Domain.Enums;

namespace Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public double AccountBalance { get; set; }
        public ICollection<Product> Products { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
