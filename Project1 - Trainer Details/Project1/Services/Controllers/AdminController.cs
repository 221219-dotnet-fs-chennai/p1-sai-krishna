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
            Log.Information("Fetching all trainers");
            return Ok(adLogic.GetTrainers());
        }

        [HttpGet("GetTrainersByGender")]
        public IActionResult GetByGender(string gender)
        {
            Log.Information("Fetching all trainers by gender");
            return Ok(adLogic.GetTrainersByGender(gender));
        }
        [HttpGet("GetTrainersByCity")]
        public IActionResult GetByCity(string city)
        {
            Log.Information("Fetching all trainers by city");
            return (adLogic.GetTrainersByCity(city))[1]!=null?Ok(adLogic.GetTrainersByCity(city)):BadRequest( " Please try again");
        }
        [HttpGet("GetTrainersByPincode")]
        public IActionResult GetByPincode(string pincode)
        {
            Log.Information("Fetching all trainers by pincode");
            return (adLogic.GetTrainersByPincode(pincode))[1] != null ? Ok(adLogic.GetTrainersByPincode(pincode)) : BadRequest(" Please try again");
           
        }
        [HttpGet("GetTrainersBySkill")]
        public IActionResult GetBySkill(string skill)
        {
            Log.Information("Fetching all trainers by skill");
            return Ok(adLogic.GetTrainersBySkill(skill));
        }
        [HttpGet("GetAllTrainersBySkill")]
        public IActionResult GetAllBySkill()
        {
            Log.Information("Fetching all trainers by skill");
            return Ok(adLogic.GetAllTrainersBySkill());
        }
    }
}
