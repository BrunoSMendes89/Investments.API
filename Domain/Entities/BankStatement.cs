namespace Domain.Entities
{
    public class BankStatement
    {
        public int BankStatementId { get; set; }
        public DateTime StatementDate { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public List<Transaction> Transactions { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
