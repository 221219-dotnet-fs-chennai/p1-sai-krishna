using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace Data__FluentApi
{
    public interface IAchivementsRepo
    {
        public Achivement addAchivement(Achivement a);

        public Achivement updateAchivement(Achivement a);
        public Achivement removeAchivement(Achivement a);

        public List<Achivement> GeAchivement(int id);
    }
}
