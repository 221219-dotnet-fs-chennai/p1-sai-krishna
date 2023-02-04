using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace Data__FluentApi
{
    public interface IAdminRepo
    {
        public List<Trainer> GetTrainers();
        public List<Trainer> GetTrainersByGender(string g);
    }
}
