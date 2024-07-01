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
        [ProducesResponseType(typeof(GetProductsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts(GetProductsRequest request)
        {
            return await CreateActionResult(request);
        }

        [HttpPost("buyproducts")]
        [ProducesResponseType(typeof(GetProductsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> BuyProduct([FromBody] BuyProductByCustomerRequest request)
        {
            return await CreateActionResult(request);
        }
    }
}