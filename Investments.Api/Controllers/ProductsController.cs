using Bases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using System.Net;

namespace Investments.Api.Controllers
{
    public class ProductsController : BaseController<ProductsController>
    {
        public ProductsController(IMediator mediator) : base(mediator) { }

        [HttpGet("GetProducts")]
        [ProducesResponseType(typeof(GetProductsResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProducts(GetProductsRequest request)
        {
            return await CreateActionResult(request);
        }
    }
}