using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IExperienceLogic
    {
        public Models.Experience addExperience(string email, Models.Experience ex);

        public Models.Experience updateExperience(string email, string exName, Models.Experience ex);
        public Models.Experience deleteExperience(string email, string exName);

        public List<Models.Experience> GetExperience(string email);
    }
}
