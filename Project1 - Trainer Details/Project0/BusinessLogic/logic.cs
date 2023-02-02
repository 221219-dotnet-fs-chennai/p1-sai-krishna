
using System.Xml.Linq;
using Data__FluentApi;
using Data__FluentApi.Entities;

namespace BusinessLogic
{

    public class logic : ITrainerLogic,ISkillLogic
    {
        TrainerContext context = new TrainerContext();
        Irepo ef=new FluentMethods();
        ISkillRepo efs = new FluentMethods();



        public Models.Trainer addTrainer(Models.Trainer trainer)
        {
            return(Mapper.TrainerMapper(ef.addTrainer(Mapper.TrainerMapper(trainer))));
        }

        public List<Models.Trainer> GetTrainers()
        {

           return  Mapper.TrainerMapper(ef.GetTrainers());
            
        }
        public bool SignIn(string uemail)
        {

            var email = context.Trainers.Where(t => t.Email == uemail).First();
            return true;
        }

        public Models.Trainer addAdditionalDeatils(Models.Trainer trainer)
        {
            var t= context.Trainers.Where(id => id.TrainerId == trainer.Id).First();
            t.Gender= trainer.Gender;
            t.City=trainer.City;
            t.State=trainer.State;
            t.Pincode=trainer.Pincode;
            t.AboutMe=trainer.AboutMe;
            return (Mapper.TrainerMapper(ef.addAdditionalDeatils(t)));
        }

        public Models.Trainer updateTrainer(Models.Trainer trainer)
        {
            var t = context.Trainers.Where(id => id.TrainerId == trainer.Id).First();
            t.Name = trainer.Name;
            t.Password = trainer.Password;
            t.PhoneNo = trainer.PhoneNo;
            t.Gender = trainer.Gender;
            t.City = trainer.City;
            t.State = trainer.State;
            t.Pincode = trainer.Pincode;
            t.AboutMe = trainer.AboutMe;

           
            return (Mapper.TrainerMapper(ef.updateTrainer(t)));
        }

        

        public Models.Trainer deleteTrainer(Models.Trainer trainer)
        {
            var t = context.Trainers.Where(id => id.TrainerId == trainer.Id).First();
            return (Mapper.TrainerMapper(ef.deleteTrainer(t)));
        }

        public Models.Skill addSkill(string email,Models.Skill s)
        {
            s.Id = Validation.IdByEmail(email);
            return Mapper.SkillMapper(efs.addSkill(Mapper.SkillMapper(s)));
        }

        public Models.Skill updateSkill(string email, string skName, Models.Skill s)
        {
            var skillToUpdate=Validation.skillByName(Validation.IdByEmail(email), skName);
            skillToUpdate.SkillName=s.Name;
            skillToUpdate.Description=s.Description;
            return Mapper.SkillMapper(efs.updateSkill(skillToUpdate));
        }

        public Models.Skill deleteSkill(string email,string skname)
        {
            var skillToDelete = Validation.skillByName(Validation.IdByEmail(email), skname);
            return Mapper.SkillMapper(efs.removeSkill(skillToDelete));
        }

        public List<Models.Skill> GetSkill(string email)
        {
            int id=Validation.IdByEmail(email);
            return Mapper.SkillMapper(efs.GetSkil(id));
        }
    }

    


}
