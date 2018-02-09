using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Get() => "Get";

        [HttpPost]
        [Route("")]
        public string Post() => "Post";

        [HttpPut]
        [Route("")]
        public string Put() => "Put";

        [HttpDelete]
        [Route("")]
        public string Delete() => "Delete";
    }
}