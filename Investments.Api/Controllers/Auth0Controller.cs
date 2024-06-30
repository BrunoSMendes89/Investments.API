using Bases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Auth0Login.Model;
using System.Net;

namespace Investments.Api.Controllers
{
    public class Auth0Controller : BaseController<Auth0Controller>
    {
        public Auth0Controller(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAuth0Token(Service.Auth0Login.Model.LoginRequest request)
        {
            return await CreateActionResult(request);
        }
    }
}