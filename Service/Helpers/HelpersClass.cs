using Domain.Entities;
using Domain.Enums;

namespace Service.Helpers
{
    public class HelpersClass
    {
        public static string SavedSuccess(int id) => $"Saved. The id it's: {id}";
        public static string UpdatedSuccess(int id) => $"Updated. The id it's: {id}";
        public static string DeletedSuccess(int id) => $"Deleted. The id it's: {id}";

        public static void UpdateBalance(Customer customer, double insertedValue, TransactionTypeEnum transactionType)
        {
            var transaction = new Transaction
            {
                Date = DateTime.Now,
                Description = transactionType == TransactionTypeEnum.Credit ? "Crédito" : "Débito",
                Amount = insertedValue,
                TransactionType = transactionType
            };

            customer.Transactions.Add(transaction);

            if (transactionType == TransactionTypeEnum.Credit)
            {
                customer.AccountBalance += insertedValue;
            }
            else 
            {
                if (customer.AccountBalance - insertedValue <= 0)
                    throw new PreconditionFailedException("Insufficient credits");
                customer.AccountBalance -= insertedValue;
            }
        }

    }
}
