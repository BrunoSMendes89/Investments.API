using Bases.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using System.Net;

namespace Investments.Api.Controllers
{
    public class ProductsController : BaseController<ProductsController>
    {
        public ProductsController(IMediator mediator) : base(mediator) { }

        [HttpGet("products")]
        [ProducesResponseType(typeof(List<GetProductsResponse>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts(GetProductsRequest request)
        {
            return await CreateActionResult(request);
        }

        [HttpPost("products")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> NegotiateProduct([FromBody] PostProductByCustomerRequest request)
        {
            return await CreateActionResult(request);
        }
    }
}