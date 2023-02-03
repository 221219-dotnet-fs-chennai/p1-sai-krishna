
using System.Xml.Linq;
using Data__FluentApi;
using Data__FluentApi.Entities;
using Models;

namespace BusinessLogic
{

    public class logic : ITrainerLogic,ISkillLogic,IAchivemensLogic
    {
        Validation v;
        TrainerContext context;
        ITrainerRepo ef;
        ISkillRepo efs;
        IAchivementsRepo efa;

        public logic(ITrainerRepo _ef, ISkillRepo efs,IAchivementsRepo _efa ,Validation _v, TrainerContext _context)
        {
            ef = _ef;
            this.efs = efs;
            efa = _efa;
            v= _v;
            context = _context;
        }
       


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

       
        public Models.Trainer updateTrainer(string email,Models.Trainer trainer)
        {
            var t = v.trainerByEmail(email);
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

        

        public Models.Trainer deleteTrainer(string email)
        {
            var t = v.trainerByEmail(email);
            return (Mapper.TrainerMapper(ef.deleteTrainer(t)));
        }



//-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public Models.Skill addSkill(string email, Models.Skill s)
        {
            s.Id = v.IdByEmail(email);
            return Mapper.SkillMapper(efs.addSkill(Mapper.SkillMapper(s)));
        }

        public Models.Skill updateSkill(string email, string skName, Models.Skill s)
        {
            var skillToUpdate = v.skillByName(v.IdByEmail(email), skName);
            skillToUpdate.SkillName = s.Name;
            skillToUpdate.Description = s.Description;
            return Mapper.SkillMapper(efs.updateSkill(skillToUpdate));
        }

        public Models.Skill deleteSkill(string email, string skname)
        {
            var skillToDelete = v.skillByName(v.IdByEmail(email), skname);
            return Mapper.SkillMapper(efs.removeSkill(skillToDelete));
        }

        public List<Models.Skill> GetSkill(string email)
        {
            int id = v.IdByEmail(email);
            return Mapper.SkillMapper(efs.GetSkil(id));
        }

//--------------------------------------------------------------------------------------------------------------------------------------------------------------

        public Achivements addAchivement(string email, Achivements a)
        {
            a.Id = v.IdByEmail(email);
            return Mapper.AchivementMapper(efa.addAchivement(Mapper.AchivementMapper(a)));
        }

        public Achivements updateAchivement(string email, string title, Models.Achivements a)
        {
            var achToUpdate = v.achivementByTitle(v.IdByEmail(email), title);
            achToUpdate.Title = a.Title;
            achToUpdate.Title = a.Description;
            return Mapper.AchivementMapper(efa.updateAchivement(achToUpdate));
        }

        public Achivements deleteAchivement(string email, string achname)
        {
            var achToDelete = v.achivementByTitle(v.IdByEmail(email), achname);
            return Mapper.AchivementMapper(efa.removeAchivement(achToDelete));
        }

        public List<Achivements> getAchivements(string email)
        {
            int id = v.IdByEmail(email);
            return Mapper.AchivementMapper(efa.GeAchivement(id));
        }
    }

 




}
