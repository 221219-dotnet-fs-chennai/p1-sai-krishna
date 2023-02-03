using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IAchivemensLogic
    {
        public Models.Achivements addAchivement(string email, Models.Achivements a);

        public Models.Achivements updateAchivement(string email, string achName, Models.Achivements a);
        public Models.Achivements deleteAchivement(string email, string achname);

        public List<Models.Achivements> getAchivements(string email);
    }
}
