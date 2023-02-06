using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace Data__FluentApi
{
    public interface IEducationRepo
    {
        public Education addEducation(Education e);

        public Education updateEducation(Education e);
        public Education removeEducation(Education e);

        public List<Education> GeEducation(int id);
    }
}
