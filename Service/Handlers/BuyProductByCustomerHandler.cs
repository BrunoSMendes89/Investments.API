using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Service.Helpers;
using Service.Models;

namespace Service.Handlers
{
    public class BuyProductByCustomerHandler : IRequestHandler<BuyProductByCustomerRequest, string>
    {
        private readonly MySqlContext _sqlContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BuyProductByCustomerHandler(MySqlContext sqlContext, IMapper mapper, IMediator mediator)
        {
            _sqlContext = sqlContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<string> Handle(BuyProductByCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _sqlContext.Customer
                .Include(c => c.Transactions)
                .Include(c => c.Products)
                .ThenInclude(p => p.Transactions)
                .FirstOrDefaultAsync(c => c.CustomerId == request.CustomerId, cancellationToken);

            if (customer == null)
                throw new PreconditionFailedException();


            var product = customer.Products.FirstOrDefault(p => p.ProductId == request.ProductId);
            if (product == null)
            {
                var model = new GetProductsRequest { Id = request.ProductId };
                var products = await _mediator.Send(model);
                var obj = products.FirstOrDefault(p => p.ProductId == request.ProductId);
                product = _mapper.Map<Product>(obj);
                product.Transactions = new List<Transaction>();
                customer.Products.Add(product);
            }
            HelpersClass.UpdateCustomerProduct(customer, product, request, request.TransactionType);

            var quantity = product.Quantity -= request.Quantity;
            var saveProduct = new PutProductRequest { ProductId = request.ProductId, Price = product.Price, ProductType = product.ProductType, DueDate = product.DueDate, Quantity = quantity };
            await _mediator.Send(saveProduct);

            await _sqlContext.SaveChangesAsync();

            return HelpersClass.SavedSuccess(customer.CustomerId);
        }
    }
}
