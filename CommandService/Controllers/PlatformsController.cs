using Microsoft.AspNetCore.Mvc;

namespace PlatformsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController: ControllerBase
    {
        public PlatformsController()
        {
            
        }
        
        [HttpPost]
        public ActionResult TestInBoundConnection()
        {
            Console.WriteLine("==> inBound post # command Service");
            
            return Ok("Inbound test of Platforms controller");
        }
    }
}