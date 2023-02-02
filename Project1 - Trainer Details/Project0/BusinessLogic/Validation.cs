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
        static TrainerContext context = new TrainerContext();
        public static int IdByEmail(string email)
        {
            var row = context.Trainers.Where(id => id.Email == email).First();
            return row.TrainerId;
        }

        public static Skill skillByName(int id,string name)
        {
            return context.Skills.Where(s=> s.TrainerId==id && s.SkillName==name).First();
        }
    }
}
