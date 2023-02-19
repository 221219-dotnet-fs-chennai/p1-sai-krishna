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
        public TrainerController(ITrainerLogic _logic, Validation _v)
        {
            logic = _logic;
            v = _v;
        }
       
        
        [HttpGet("getTrainerDetails")]
        public ActionResult Get([FromHeader]string email)
        {
            
            var trainer = logic.GetTrainer(email);
            if (trainer != null)
            {
                Log.Information("Fetching trainer details");
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
            try
            {
                if (v.isEmailPresent(t.Email) == false)
                {
                    Log.Information(" New trainer Sign up");
                    return Ok(logic.addTrainer(t));
                }
                else
                {
                    return BadRequest("Email already exists,please sign in");
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message+", Please try again");
            }
        }

        [HttpGet("signIn")]
        public ActionResult SignIn([FromHeader]string email, [FromHeader] string password)
        {
            if (v.isEmailPresent(email) == true)
            {
                if (v.signIn(email, password))
                {
                    Log.Information(" trainer login");
                    return Ok("Successful login");
                }
                else
                {
                    return BadRequest("Wrong password");
                }
            }
            else
            {
                Log.Information(" logged in with non existing email");
                return BadRequest("Email does not exists,please sign up");
            }
        }

        [HttpPut("UpdateTrainer")]
        public ActionResult Put([FromHeader] string email, [FromBody] Trainer t)
        {
            try
            {
                Log.Information("Updating trainer details");
                return Ok(logic.updateTrainer(email, t));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message + ", Please try again");
            }
        }

        [HttpDelete("DeleteAccount")] 
        public ActionResult Delete([FromHeader] string email)
        {
            Log.Information("Account Deleted");
            return Ok(logic.deleteTrainer(email));
        }
    }

    
}
