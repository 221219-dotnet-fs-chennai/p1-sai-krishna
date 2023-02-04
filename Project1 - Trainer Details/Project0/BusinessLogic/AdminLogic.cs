using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi;
using Data__FluentApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class AdminLogic : IAdminLogic
    {
        IAdminRepo adRepo;
        public AdminLogic(IAdminRepo _adRepo)
        {
            adRepo= _adRepo;
        }
        public List<Models.Trainer> GetTrainers()
        {
           return Mapper.TrainerMapper(adRepo.GetTrainers());
        }

        public List<Models.Trainer> GetTrainersByGender(string g)
        {
            return Mapper.TrainerMapper(adRepo.GetTrainersByGender(g));
        }
    }
}
