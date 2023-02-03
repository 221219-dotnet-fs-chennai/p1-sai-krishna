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
        
        public TrainerController(ITrainerLogic _logic)
        {
            logic = _logic;
          
        }
       

        [HttpGet]
        public ActionResult Get()
        {
            var listT=logic.GetTrainers();
            if (listT != null)
            {
                return Ok(listT);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost("signUp")]
        public ActionResult Post(Trainer t)
        {
           
            return Ok(logic.addTrainer(t));
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
