using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        ITrainerLogic logic;
        Validation v;
        public TrainerController(ITrainerLogic _logic,Validation _v)
        {
            logic = _logic;
            v = _v;
        }
       

        [HttpGet("getTrainerDetails")]
        public ActionResult Get(string email)
        {
            var trainer=logic.GetTrainer(email);
            if (trainer != null)
            {
                return Ok(trainer);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost("signUp")]
        public ActionResult Post(Trainer t)
        {
           if(v.isEmailPresent(t.email)==false)
            {
                return Ok(logic.addTrainer(t));
            }
            else
            {
                return BadRequest("Email already exists,please sign in");
            }
        }

        [HttpGet("signIn")]
        public ActionResult SignIn(string email,string password)
        {
            if (v.isEmailPresent(email) == true)
            {
                if(v.signIn(email,password))
                {
                    return Ok("Successful login");
                }
                else
                {
                    return BadRequest("Wrong passowrd");
                }
            }
            else
            {
                return BadRequest("Email does not exists,please sign up");
            }
        }

        [HttpPut("UpdateTrainer")]
        public ActionResult Put([FromHeader]string email,[FromBody]Trainer t)
        {
            return Ok(logic.updateTrainer(email,t));
        }

        [HttpDelete("DeleteAccount")]
        public ActionResult Delete([FromHeader]string email)
        {
            return Ok(logic.deleteTrainer(email));
        }
       
    }
}
