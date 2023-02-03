using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IEducationLogic
    {
        public Models.Education addEducation(string email, Models.Education e);

        public Models.Education updateEducation(string email, string eduName, Models.Education e);
        public Models.Education deleteEducation(string email, string eduname);

        public List<Models.Education> GetEducation(string email);
    }
}
