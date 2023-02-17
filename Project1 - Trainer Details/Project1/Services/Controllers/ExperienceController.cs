using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        IExperienceLogic exlogic;
        public ExperienceController(IExperienceLogic _exlogic)
        {

            exlogic = _exlogic;
        }
        [HttpGet("DisplayExperience")]
        public ActionResult Get([FromHeader] string email)
        {
            var experiences = exlogic.GetExperience(email);
            return Ok(experiences);
        }

        [HttpPost("InsertExperience")]
        public ActionResult Post(string email, Experience s)
        {
            return Ok(exlogic.addExperience(email, s));
        }
        [HttpPut("UpdateExperience")]
        public ActionResult Put([FromHeader] string email, [FromHeader] string companyName, [FromBody] Experience ex)
        {
            return Ok(exlogic.updateExperience(email, companyName, ex));
        }
        [HttpDelete("DeleteExperience")]
        public ActionResult Delete([FromHeader] string email, [FromHeader] string companyName)
        {
            return Ok(exlogic.deleteExperience(email, companyName));
        }
    }
}
