using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bases.Controllers
{
    public abstract class BaseController<TController> : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> CreateActionResult<T>(T model)
        {
            try
            {
                if (model == null)
                    throw new NotImplementedException();
                var result = await _mediator.Send(model);
                if (result is FileStreamResult fileStream)
                    return fileStream;

                return Ok(result);
            }
            catch (PreconditionFailedException ex)
            {
                return new ConflictObjectResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.PreconditionFailed
                };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

    }
}
