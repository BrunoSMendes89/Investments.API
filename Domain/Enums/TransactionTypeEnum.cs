using System.ComponentModel;

namespace Domain.Enums
{
    public enum TransactionTypeEnum
    {
        [Description("Crédito")]
        Credit,
        [Description("Débito")]
        Debit,
        [Description("Compra")]
        Buy,
        [Description("Venda")]
        Sell
    }
}
