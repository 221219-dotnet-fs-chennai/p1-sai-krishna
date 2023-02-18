using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        public List<Models.Trainer> GetTrainersByCity(string city)
        {
            return Mapper.TrainerMapper(adRepo.GetTrainersByCity(city));
        }

        public List<Models.Trainer> GetTrainersByGender(string gender)
        {
            return Mapper.TrainerMapper(adRepo.GetTrainersByGender(gender));
        }

        public List<Models.Trainer> GetTrainersByPincode(string pin)
        {
            return Mapper.TrainerMapper(adRepo.GetTrainersByPincode(pin));
        }

        public List<Models.Trainer> GetTrainersBySkill(string skill)
        {
            return Mapper.TrainerMapper(adRepo.GetTrainersBySkill(skill));
        }
        public Dictionary<string, List<List<string>>> GetAllTrainersBySkill()
        {
            return adRepo.GetAllTrainersBySkill();
        }
    }
}
