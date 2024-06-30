using Domain.Enums;

namespace Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public int BankStatementId { get; set; }
        public BankStatement BankStatement { get; set; }
    }
}
