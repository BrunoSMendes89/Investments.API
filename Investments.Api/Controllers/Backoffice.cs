using Bases.Controllers;
using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using System.Net;

namespace Investments.Api.Controllers
{
    public class Backoffice : BaseController<Backoffice>
    {
        public Backoffice(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("createuser")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreaterUser([FromBody] PostUserRequest request)
        {
            return await CreateActionResult(request);
        }

        [HttpPost("createcustomer")]
        [ProducesResponseType(typeof(CustomerModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreaterCustomer([FromBody] PostCustomerRequest request)
        {
            return await CreateActionResult(request);
        }

        [HttpPost("createproduct")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProduct([FromBody] PostProductRequest request)
        {
            return await CreateActionResult(request);
        }

        [HttpPut("product/{productId}")]
        [ProducesResponseType(typeof(ProductModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProduct(int productId, double price, int quantity, ProductTypeEnum productType, DateTime dueDate)
        {
            return await CreateActionResult(new PutProductRequest { ProductId = productId, Price = price, Quantity = quantity, ProductType = productType, DueDate = dueDate });
        }

        [HttpDelete("product/{productId}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            return await CreateActionResult(new DeleteProductRequest { ProductId = productId});
        }

        [HttpPost("email")]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SendEmail(SendEmailNotification request)
        {
            return await CreateActionResult(request);
        }
    }
}
