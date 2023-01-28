using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;


namespace Models
{
    public interface IFluentApiRepo
    {
       
        public  List<Trainer> GetTrainers();

        public List<Skill> GetSkils(int id);
    }
}
