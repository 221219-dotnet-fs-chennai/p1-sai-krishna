using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace Data__FluentApi
{
    public interface ITrainerRepo
    {
        public Trainer GetTrainer(int id);

       
        public Trainer addTrainer(Trainer trainer);
       
        public Trainer updateTrainer(Trainer trainer);
        public Trainer deleteTrainer(Trainer trainer);

        
    }
}
