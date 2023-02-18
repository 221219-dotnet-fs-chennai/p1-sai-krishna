﻿using BusinessLogic;
using Data__FluentApi.Entities;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchivementsController : ControllerBase
    {
        IAchivemensLogic alogic;
        public AchivementsController(IAchivemensLogic _alogic)
        {

            alogic = _alogic;
        }
        [HttpGet("DisplayAchivements")]
        public ActionResult Get([FromHeader] string email)
        {
            var skills = alogic.getAchivements(email);
            return Ok(skills);
        }

        [HttpPost("InsertAchivement")]
        public ActionResult Post([FromHeader]string email,[FromBody] Achivements a)
        {
            return Ok(alogic.addAchivement(email, a));
        }
        [HttpPut("UpdateAchivement")]
        public ActionResult Put([FromHeader] string email, [FromHeader] string achivementName, [FromBody] Achivements ach)
        {
            return Ok(alogic.updateAchivement(email, achivementName, ach));
        }
        [HttpDelete("DeleteAchivement")]
        public ActionResult Delete([FromHeader] string email, [FromHeader] string achivementName)
        {
            return Ok(alogic.deleteAchivement(email, achivementName));
        }
    }
}
