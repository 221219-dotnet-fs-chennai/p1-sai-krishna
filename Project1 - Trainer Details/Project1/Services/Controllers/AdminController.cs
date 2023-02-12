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
        public IActionResult GetByGender(string gender)
        {
            return Ok(adLogic.GetTrainersByGender(gender));
        }
        [HttpGet("GetTrainersByCity")]
        public IActionResult GetByCity(string city)
        {
            return Ok(adLogic.GetTrainersByCity(city));
        }
        [HttpGet("GetTrainersByPincode")]
        public IActionResult GetByPincode(string pincode)
        {
            return Ok(adLogic.GetTrainersByPincode(pincode));
        }
        [HttpGet("GetTrainersBySkill")]
        public IActionResult GetBySkill(string skill)
        {
            return Ok(adLogic.GetTrainersBySkill(skill).Values);
        }
        [HttpGet("GetAllTrainersBySkill")]
        public IActionResult GetAllBySkill()
        {
            return Ok(adLogic.GetAllTrainersBySkill());
        }
    }
}
