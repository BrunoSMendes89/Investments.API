using Domain.Enums;

namespace Domain.Models
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public int CustomerId { get; set; }
        public int? ProductId { get; set; }
    }
}
