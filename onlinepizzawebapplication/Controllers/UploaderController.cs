using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlinepizzawebapplication.Models;

namespace onlinepizzawebapplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploaderController : ControllerBase
    {
        [HttpPost]
        [Route("UploadFile")]
        public Response UploadFile()
        {
            Response response=new Response();
            return response;

        }
    }
}
