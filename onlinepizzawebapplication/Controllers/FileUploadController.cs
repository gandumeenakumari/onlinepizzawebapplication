using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlinepizzawebapplication.Models;

namespace onlinepizzawebapplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        public FileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task<string> Post([FromForm] FileUpload fileupload)

        {
            try
            {
                if(fileupload.files.Length> 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if(!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream filestream=System.IO.File.Create(path+fileupload.files.FileName))
                    {
                        fileupload.files.CopyTo(filestream);
                        filestream.Flush();
                        return "Upload Done";
                    }
                }
                else
                {
                    return "Failed";
                }
            }
            catch(Exception ex)
            {
                return ex.Message;   
            }
        }
        [HttpGet("{fileName}")]
        public async Task<IActionResult> Get([FromRoute] string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName + ".jpg";
            if(System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/png");
            }
            return null;

        }
    }

}
