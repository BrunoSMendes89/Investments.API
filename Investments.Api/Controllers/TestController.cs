using Microsoft.AspNetCore.Mvc;

namespace Investments.Api.Controllers
{
    public class TestController : Controller
    {
        [HttpGet("HelloWorld")]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
