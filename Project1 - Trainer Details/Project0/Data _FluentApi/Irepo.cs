using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace Data__FluentApi
{
    public interface Irepo
    {
        public List<Trainer> GetTrainers();

        public bool SignIn(string uemail);
        public Trainer addTrainer(Trainer trainer);
        public Trainer addAdditionalDeatils(Trainer trainer);
        public Trainer updateTrainer(Trainer trainer);
        public Trainer deleteTrainer(Trainer trainer);

        //public void addSkill(Skill s);

        ////public void updateSkill(Skill skill);
        //public void removeSkill(Skill s);

        //public List<Skill> GetSkil(int id);
    }
}
