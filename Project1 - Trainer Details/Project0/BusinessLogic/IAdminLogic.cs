using System;
using System.Collections.Generic;
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
    }
}
