using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminLogic adLogic;
        public AdminController(IAdminLogic _adLogic)
        {
            adLogic= _adLogic;
        }
        [HttpGet("GetAllTrainers")]
        public IActionResult Get()
        {
            return Ok(adLogic.GetTrainers());
        }

        [HttpGet("GetTrainersByGender")]
        public IActionResult GetGender(string g)
        {
            return Ok(adLogic.GetTrainersByGender(g));
        }
    }
}
