using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Service.Helpers;
using Service.Models;

namespace Service.Handlers
{
    public class PostProductByCustomerHandler : IRequestHandler<PostProductByCustomerRequest, string>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PostProductByCustomerHandler(MySqlContext sqlContext, IMapper mapper, IMediator mediator)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<string> Handle(PostProductByCustomerRequest request, CancellationToken cancellationToken)
        {
            if(request.TransactionType != Domain.Enums.TransactionTypeEnum.Buy || request.TransactionType != Domain.Enums.TransactionTypeEnum.Sell)
                throw new PreconditionFailedException("Transaction Type not Allowed");

            var customer = await _sqlContext.Customer
                .Include(c => c.Transactions)
                .Include(c => c.CustomerProducts)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.Transactions)
                .FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId, cancellationToken);

            if (customer == null)
                throw new PreconditionFailedException();


            var customerProduct = customer.CustomerProducts.FirstOrDefault(p => p.ProductId == request.ProductId);
            var product = customerProduct.Product;
            if (product == null)
            {
                var model = new GetProductsRequest { Id = request.ProductId };
                var products = await _mediator.Send(model);
                var obj = products.FirstOrDefault(p => p.ProductId == request.ProductId);
                product = _mapper.Map<Product>(obj);
                product.Transactions = new List<Transaction>();
                customer.CustomerProducts.Add(CustomerProduct(customer, product,request));
            }
            HelpersClass.UpdateCustomerProduct(customer, product, request, request.TransactionType);

            var quantity = product.Quantity -= request.Quantity;
            var saveProduct = new PutProductRequest { ProductId = request.ProductId, Price = product.Price, ProductType = product.ProductType, DueDate = product.DueDate, Quantity = quantity };
            
            _sqlContext.Update(customer);
            await _sqlContext.SaveChangesAsync();

            return HelpersClass.SavedSuccess(customer.CustomerId);
        }

        private static CustomerProduct CustomerProduct(Customer customer, Product product, PostProductByCustomerRequest request)
        {
            return new CustomerProduct { Customer = customer, Product = product, Quantity = request.Quantity };
        }
    }
}
