using Data__FluentApi.Entities;
namespace Data__FluentApi
{
    public  class FluentMethods:Irepo
    {
        Project0Context context = new Project0Context();

        public bool SignIn(string uemail)
        {

            var email = context.Trainers.Where(t => t.Email == uemail).First();
            return true;
        }
        public Trainer addTrainer(Trainer trainer)
        {  
            context.Trainers.Add(trainer);
            context.SaveChanges();
            return trainer;
        }

        public List<Trainer> GetTrainers()
        {


            return context.Trainers.ToList();
        }

        public Trainer addAdditionalDeatils(Trainer trainer)
        {
            context.Trainers.Update(trainer);
            context.SaveChanges();
            return trainer;
        }

        public Trainer updateTrainer(Trainer trainer)
        {
            context.Trainers.Update(trainer);
            context.SaveChanges();
            return trainer;
        }

        public Trainer deleteTrainer(Trainer trainer)
        {
            context.Trainers.Remove(trainer);
            context.SaveChanges();
            return trainer;
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
}
    