using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        IEducationLogic elogic;
        public EducationController(IEducationLogic _elogic)
        {

            elogic = _elogic;
        }
        [HttpGet("DisplayEducations")]
        public ActionResult Get([FromHeader] string email)
        {
            Log.Information("Fetching trainer Educations");
            var skills = elogic.GetEducation(email);
            return Ok(skills);
        }

        [HttpPost("InsertEducation")]
        public ActionResult Post([FromHeader]string email, [FromBody] Education s)
        {
            try
            {
                Log.Information("Inserting trainer Educations");
                return Ok(elogic.addEducation(email, s));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ", Please try again");
            }
        }
        [HttpPut("UpdateEducation")]
        public ActionResult Put([FromHeader] string email, [FromHeader] string InstituteName, [FromBody] Education Education)
        {
            try
            {
                Log.Information("Updating trainer Educations");
                return Ok(elogic.updateEducation(email, InstituteName, Education));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ", Please try again");
            }
        }
        [HttpDelete("DeleteEducation")]
        public ActionResult Delete([FromHeader] string email, [FromHeader] string InstituteName)
        {
            Log.Information("Deleting trainer Educations");
            return Ok(elogic.deleteEducation(email, InstituteName));
        }
    }
}
