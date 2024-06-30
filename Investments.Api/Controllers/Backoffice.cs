using Bases;
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
        public async Task<IActionResult> GetProducts(PostCustomerRequest request)
        {
            return await CreateActionResult(request);
        }

    }
}
