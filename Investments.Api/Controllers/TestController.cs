using Bases.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Models;
using System.Net;

namespace Investments.Api.Controllers
{
    public class TestController : BaseController<TestController>
    {
        public TestController(IMediator mediator) : base(mediator){}

        [HttpGet("TestHandler")]
        [ProducesResponseType(typeof(TestResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Testhandlers(TestRequest request)
        {
            return await CreateActionResult(request);
        }
    }
}
