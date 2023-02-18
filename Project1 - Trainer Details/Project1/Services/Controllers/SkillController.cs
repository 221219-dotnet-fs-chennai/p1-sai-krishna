﻿using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        ISkillLogic slogic;
        public SkillController(ISkillLogic _Slogic)
        {

            slogic = _Slogic;
        }
        [HttpGet("DisplaySkills")]
        public ActionResult Get([FromHeader] string email)
        {
            var skills=slogic.GetSkill(email);
            return Ok(skills);
        }

        [HttpPost("InsertSkill")] 
        public ActionResult Post([FromHeader]string email, [FromBody]Skill s)
        {
            return Ok(slogic.addSkill(email,s));
        }
        [HttpPut("UpdateSkill")]
        public ActionResult Put([FromHeader]string email,[FromHeader]string skillName,[FromBody] Skill skill)
        {
            return Ok(slogic.updateSkill(email, skillName, skill));
        }
        [HttpDelete("DeleteSkill")]
        public ActionResult Delete([FromHeader] string email, [FromHeader] string skillName)
        {
            return Ok(slogic.deleteSkill(email,skillName));
        }
    }
}
