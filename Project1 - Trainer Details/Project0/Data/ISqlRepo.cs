using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{

    public interface ISqlRepo
    {
        
        void addData(Trainer trainer);
        Trainer getData(Trainer trainer);
        bool deleteData(Trainer trainer);
        void updateData(Trainer trainer);
    }
}
