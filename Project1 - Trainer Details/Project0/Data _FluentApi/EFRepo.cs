using Data__FluentApi.Entities;
namespace Data__FluentApi
{
    public  class EFRepo:ITrainerRepo,ISkillRepo,IAchivementsRepo,IEducationRepo,IExperienceRepo
    {
        TrainerContext context;
        public EFRepo(TrainerContext context)
        {
            this.context = context;
        }

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

        public Trainer GetTrainer(int id)
        {
          return context.Trainers.Where(t=>t.TrainerId==id).FirstOrDefault();
                          
           
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
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        public Skill addSkill(Skill s)
        {
            context.Skills.Add(s);
            context.SaveChanges();
            return s;
        }

        public Skill updateSkill(Skill s)
        {
            context.Skills.Update(s);
            context.SaveChanges();
            return s;
        }

        public Skill removeSkill(Skill s)
        {
            context.Skills.Remove(s);
            context.SaveChanges();
            return s;
        }

        public List<Skill> GetSkil(int id)
        {
            var skills = from s in context.Skills
                         where s.TrainerId == id
                         select s;
            return skills.ToList();
        }



        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           
        public Achivement addAchivement(Achivement a)
        {
            context.Achivements.Add(a);
            context.SaveChanges();
            return a;
        }

        public Achivement updateAchivement(Achivement a)
        {
            context.Achivements.Update(a);
            context.SaveChanges();
            return a;
        }

        public Achivement removeAchivement(Achivement a)
        {
            context.Achivements.Remove(a);
            context.SaveChanges();
            return a;
        }

        public List<Achivement> GeAchivement(int id)
        {
            var achivements = from a in context.Achivements
                         where a.TrainerId == id
                         select a;
            return achivements.ToList();
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public Education addEducation(Education e)
        {
            context.Educations.Add(e);
            context.SaveChanges();
            return e;
        }

        public Education updateEducation(Education e)
        {
            context.Educations.Update(e);
            context.SaveChanges();
            return e;
        }

        public Education removeEducation(Education e)
        {
            context.Educations.Remove(e);
            context.SaveChanges();
            return e;
        }

        public List<Education> GeEducation(int id)
        {
            var educations = from a in context.Educations
                              where a.TrainerId == id
                              select a;
            return educations.ToList();
        }
 //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public Experience addExperience(Experience ex)
        {
            context.Experiences.Add(ex);
            context.SaveChanges();
            return ex;
        }

        public Experience updateExperience(Experience ex)
        {
            context.Experiences.Update(ex);
            context.SaveChanges();
            return ex;
        }

        public Experience removeExperience(Experience ex)
        {
            context.Experiences.Remove(ex);
            context.SaveChanges();
            return ex;
        }

        public List<Experience> GeExperience(int id)
        {
            var experiences = from a in context.Experiences
                             where a.TrainerId == id
                             select a;
            return experiences.ToList();
        }

    }
}
    