using Bases.Extensions;
using Domain.Entities;
using Domain.Enums;
using Persistence.Context;
using Service.Models;
using System.Threading;

namespace Service.Helpers
{
    public class HelpersClass
    {
        public static string SavedSuccess(int id) => $"Saved. The id is: {id}";
        public static string UpdatedSuccess(int id) => $"Updated. The id is: {id}";
        public static string DeletedSuccess(int id) => $"Deleted. The id is: {id}";

        public static void UpdateBalance(Customer customer, double insertedValue, TransactionTypeEnum transactionType)
        {
            var transaction = new Transaction
            {
                Date = DateTime.Now,
                Description = transactionType.GetDescription(),
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

        public static void UpdateCustomerProduct(Customer customer, Product product, BuyProductByCustomerRequest request, TransactionTypeEnum transactionType)
        {
            var transaction = new Transaction
            {
                Date = DateTime.Now,
                Description = transactionType.GetDescription(),
                Amount = request.Quantity,
                TransactionType = transactionType,
                Customer = customer,
                Product = product
            };


            customer.Transactions.Add(transaction);
            product.Transactions.Add(transaction);

            var customerProduct = customer.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

            if (transactionType == TransactionTypeEnum.Buy)
            {
                if (customerProduct != null)
                {
                    customerProduct.Quantity += request.Quantity;
                }
                else
                {
                    var newProduct = new Product
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Price = product.Price,
                        Quantity = request.Quantity
                    };
                    customer.Products.Add(newProduct);
                }

                product.Quantity -= request.Quantity;
                if ((customer.AccountBalance - (product.Price * request.Quantity)) < 0)
                    throw new PreconditionFailedException("Insufficient credits");
                customer.AccountBalance -= product.Price * request.Quantity;
            }
            else if (transactionType == TransactionTypeEnum.Sell)
            {
                if (customerProduct == null || customerProduct.Quantity < request.Quantity)
                    throw new PreconditionFailedException("Quantity more than we have to sell.");

                customerProduct.Quantity -= request.Quantity;
                if (customerProduct.Quantity == 0)
                {
                    customer.Products.Remove(customerProduct);
                }

                product.Quantity += request.Quantity;
                customer.AccountBalance += product.Price * request.Quantity;
            }
        }

        //public static void UpdateCustomerProduct(Customer customer, Product product, BuyProductByCustomerRequest request, TransactionTypeEnum transactionType)
        //{
        //    var transaction = new Transaction
        //    {
        //        Date = DateTime.Now,
        //        Description = transactionType.GetDescription(),
        //        Amount = request.Quantity,
        //        TransactionType = transactionType,
        //        Customer = customer,
        //        Product = product
        //    };

        //    if (product == null)
        //        product = new Product { Transactions = new List<Transaction>() };

        //    customer.Transactions.Add(transaction);
        //    product.Transactions.Add(transaction);

        //    var customerProduct = customer.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

        //    if (transactionType == TransactionTypeEnum.Buy)
        //    {
        //        if (customerProduct != null)
        //        {
        //            customerProduct.Quantity += request.Quantity;
        //        }
        //        else
        //        {
        //            var newProduct = new Product
        //            {
        //                ProductId = product.ProductId,
        //                Name = product.Name,
        //                Price = product.Price,
        //                Quantity = request.Quantity
        //            };
        //            customer.Products.Add(newProduct);
        //        }

        //        product.Quantity -= request.Quantity;
        //        if ((customer.AccountBalance - (product.Price * request.Quantity)) <= 0)
        //            throw new PreconditionFailedException("Insufficient credits");
        //        customer.AccountBalance -= product.Price * request.Quantity;
        //    }
        //    else if (transactionType == TransactionTypeEnum.Sell)
        //    {
        //        if (product.Quantity - request.Quantity <= 0)
        //            throw new PreconditionFailedException("Quantity more than we have to sell.");
        //        product.Quantity += request.Quantity;
        //        customer.AccountBalance += product.Price;
        //        customer.Products.Remove(product);
        //    }
        //}
    }
}
