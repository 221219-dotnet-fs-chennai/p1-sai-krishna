using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace BusinessLogic
{
    public class Validation
    {
         TrainerContext context;
        public Validation(TrainerContext _context)
        {
            context = _context;
        }

        public  int IdByEmail(string email)
        {
            var row = context.Trainers.Where(id => id.Email == email).FirstOrDefault();
            return row.TrainerId;
        }
        public Trainer trainerByEmail(string email)
        {
            var row = context.Trainers.Where(id => id.Email == email).FirstOrDefault();
            return row;
        }

        public  Skill skillByName(int id,string name)
        {
            return context.Skills.Where(s=> s.TrainerId==id && s.SkillName==name).First();
        }

        public Achivement achivementByTitle(int id, string title)
        {
            return context.Achivements.Where(a => a.TrainerId == id && a.Title == title).First();
        }

        public Education educationByName(int id, string name)
        {
            return context.Educations.Where(a => a.TrainerId == id && a.InstituteName == name).First();
        }

        public Experience experienceByName(int id, string name)
        {
            return context.Experiences.Where(a => a.TrainerId == id && a.CmpName == name).First();
        }
    }
}
