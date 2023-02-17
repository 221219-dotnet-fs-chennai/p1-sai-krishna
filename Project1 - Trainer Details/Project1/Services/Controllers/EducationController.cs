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
            var skills = elogic.GetEducation(email);
            return Ok(skills);
        }

        [HttpPost("InsertEducation")]
        public ActionResult Post(string email, Education s)
        {
            return Ok(elogic.addEducation(email, s));
        }
        [HttpPut("UpdateEducation")]
        public ActionResult Put([FromHeader] string email, [FromHeader] string InstituteName, [FromBody] Education Education)
        {
            return Ok(elogic.updateEducation(email, InstituteName, Education));
        }
        [HttpDelete("DeleteEducation")]
        public ActionResult Delete([FromHeader] string email, [FromHeader] string InstituteName)
        {
            return Ok(elogic.deleteEducation(email, InstituteName));
        }
    }
}
