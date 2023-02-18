using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace BusinessLogic
{
    public interface IAdminLogic
    {
        public List<Models.Trainer> GetTrainers();
        public List<Models.Trainer> GetTrainersByGender(string g);
        public List<Models.Trainer> GetTrainersByCity(string g);
        public List<Models.Trainer> GetTrainersByPincode(string g);
        public List<Models.Trainer> GetTrainersBySkill(string g);
        public Dictionary<string, List<List<string>>> GetAllTrainersBySkill();



    }
}
