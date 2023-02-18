using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data__FluentApi
{
    public class EFAdminRepo : IAdminRepo
    {
        TrainerContext context;
        public EFAdminRepo(TrainerContext context)
        {
            this.context = context;
        }
        public List<Trainer> GetTrainers()
        {
            return context.Trainers.ToList();
        }

        public List<Trainer> GetTrainersByCity(string city)
        {
            return context.Trainers.Where(t => t.City == city).ToList();
        }

        public List<Trainer> GetTrainersByGender(string g)
        {
            return context.Trainers.Where(t=>t.Gender==g).ToList();
        }

        public List<Trainer> GetTrainersByPincode(string pincode)
        {
            return context.Trainers.Where(t => t.Pincode == pincode).ToList();
        }
        public List<Trainer> GetTrainersBySkill(string g)
        {
           
            var skil = (from t in context.Trainers
                          join s in context.Skills
                          on t.TrainerId equals s.TrainerId
                          where s.SkillName == g
                          select t).ToList();
           
            return skil;
        }
        public Dictionary<string, List<List<string>>> GetAllTrainersBySkill()
        {
            List <string[]> lis=new List<string[]>();
            Dictionary<string, List<List<string>>> ski = new Dictionary<string, List<List<string>>>();
            var skills = (from t in context.Trainers
                        join s in context.Skills
                        on t.TrainerId equals s.TrainerId
                        //where s.SkillName == g
                        select new
                        {
                            t.Name,
                            t.Gender,
                            t.Email,
                            s.SkillName

                        }).ToList();
            foreach (var si in skills)
            {
                if (ski.ContainsKey(si.SkillName))
                {
                    ski[si.SkillName].Add(new List<string> { si.Name, si.Email, si.Name });
                }
                else { 
                ski.Add(si.SkillName, new List<List<string>> { new List<string> { si.Name,si.Email,si.Name} });
                    }
            }
            return ski;
        }
    }
}
