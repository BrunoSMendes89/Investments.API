using Bases.Controllers;
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

        [HttpPost("createcustomer")]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreaterCustomer([FromBody] PostCustomerRequest request)
        {
            return await CreateActionResult(request);
        }

        [HttpPost("createproduct")]
        [ProducesResponseType(typeof(Unit), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProduct([FromBody] PostProductRequest request)
        {
            return await CreateActionResult(request);
        }


    }
}
