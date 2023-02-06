using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace Data__FluentApi
{
    public interface IExperienceRepo
    {
        public Experience addExperience(Experience ex);

        public Experience updateExperience(Experience ex);
        public Experience removeExperience(Experience ex);

        public List<Experience> GeExperience(int id);
    }
}
