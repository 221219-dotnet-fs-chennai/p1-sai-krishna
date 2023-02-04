using System;
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

        public List<Trainer> GetTrainersByGender(string g)
        {
            return context.Trainers.Where(t=>t.Gender==g).ToList();
        }
    }
}
