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
             return (adLogic.GetTrainersByCity(city))[1]!=null?Ok(adLogic.GetTrainersByCity(city)):BadRequest( " Please try again");
        }
        [HttpGet("GetTrainersByPincode")]
        public IActionResult GetByPincode(string pincode)
        {
            return (adLogic.GetTrainersByPincode(pincode))[1] != null ? Ok(adLogic.GetTrainersByPincode(pincode)) : BadRequest(" Please try again");
           
        }
        [HttpGet("GetTrainersBySkill")]
        public IActionResult GetBySkill(string skill)
        {
            return Ok(adLogic.GetTrainersBySkill(skill));
        }
        [HttpGet("GetAllTrainersBySkill")]
        public IActionResult GetAllBySkill()
        {
            return Ok(adLogic.GetAllTrainersBySkill());
        }
    }
}
