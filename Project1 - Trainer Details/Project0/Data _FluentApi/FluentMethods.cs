﻿using Data__FluentApi.Entities;
namespace Data__FluentApi
{
    public  class FluentMethods:ITrainerRepo,ISkillRepo,IAchivementsRepo,IEducationRepo
    {
        TrainerContext context;
        public FluentMethods(TrainerContext context)
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
            var Educations = from a in context.Educations
                              where a.TrainerId == id
                              select a;
            return Educations.ToList();
        }
    }
}
    