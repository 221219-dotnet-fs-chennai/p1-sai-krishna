using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace BusinessLogic
{
    public interface ITrainerLogic
    {
       
        public  List<Models.Trainer> GetTrainers();

        public bool SignIn(string uemail);
        public Models.Trainer addTrainer(Models.Trainer trainer);
        public Models.Trainer addAdditionalDeatils(Models.Trainer trainer);
        public Models.Trainer updateTrainer(Models.Trainer trainer);
        public Models.Trainer deleteTrainer(Models.Trainer trainer);

        
    }
}
