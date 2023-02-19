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
            Log.Information("Fetching trainer Experiences");
            var experiences = exlogic.GetExperience(email);
            return Ok(experiences);
        }

        [HttpPost("InsertExperience")]
        public ActionResult Post([FromHeader] string email, [FromBody] Experience s)
        {

            try
            {
                Log.Information("Inserting trainer Experiences");
                return Ok(exlogic.addExperience(email, s));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ", Please try again");
            }
        }
        [HttpPut("UpdateExperience")]
        public ActionResult Put([FromHeader] string email, [FromHeader] string companyName, [FromBody] Experience ex)
        {
            try
            {
                Log.Information("Updating trainer Experiences");
                return Ok(exlogic.updateExperience(email, companyName, ex));
            }
            catch (Exception exe)
            {
                return BadRequest(exe.Message + ", Please try again");
            }
        }
        [HttpDelete("DeleteExperience")]
        public ActionResult Delete([FromHeader] string email, [FromHeader] string companyName)
        {
            Log.Information("Deleting trainer Experiences");
            return Ok(exlogic.deleteExperience(email, companyName));
        }
    }
}
