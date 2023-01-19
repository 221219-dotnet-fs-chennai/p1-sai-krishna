using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IchildSql
    {
        void add(int id);
        void update(int id);
        void delete(int id);
        void view(int id);
    }
}
