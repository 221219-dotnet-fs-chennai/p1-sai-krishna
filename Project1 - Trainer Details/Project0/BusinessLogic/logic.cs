
using Data__FluentApi;
using Data__FluentApi.Entities;

namespace BusinessLogic
{

    public class logic : ILogic
    {
        Project0Context context = new Project0Context();
        FluentMethods ef=new FluentMethods();

       

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
            t.Name=trainer.Name;
            t.Password=trainer.Password;
            t.PhoneNo=trainer.PhoneNo;
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
    }

    //public void addSkill(Skill s)
    //{
    //    context.Skills.Add(s);
    //    context.SaveChanges();
    //    Console.WriteLine("skills added");
    //}


    //public List<Skill> GetSkil(int id)
    //{


    //    var skills = from s in context.Skills
    //                 where s.TrainerId == id
    //                 select s;
    //    return skills.ToList();
    //}



    //public void removeSkill(Skill sk)
    //{

    //    var skillToBeRemoved = context.Skills.Where(s => s.SkillName == sk.SkillName).FirstOrDefault();
    //    context.Skills.Remove(skillToBeRemoved);
    //    context.SaveChanges();

    //    Console.WriteLine("Skill Removed");

    //}

    ////public void updateSkill(Skill skill)
    ////{

    ////    var presentSills = GetSkil(id);
    ////    var allSkills = from s in context.Skills
    ////                    where s.TrainerId == s.TrainerId 
    ////                    select s;


    ////}


}
