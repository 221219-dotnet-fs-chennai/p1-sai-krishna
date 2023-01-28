using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace BusinessLogic
{
    public interface IFluentApiRepo
    {
       
        public  List<Trainer> GetTrainers();

        public void addTrainer(Trainer trainer);

        public void addSkill(Skill s);

        public List<Skill> GetSkil(int id);
    }
}
