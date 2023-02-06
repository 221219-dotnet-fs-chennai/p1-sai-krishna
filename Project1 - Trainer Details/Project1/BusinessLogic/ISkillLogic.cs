using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace BusinessLogic
{
    public interface  ISkillLogic
    {
        public Models.Skill addSkill(string email,Models.Skill s);

        public Models.Skill  updateSkill(string email,string skName,Models.Skill s);
        public Models.Skill deleteSkill(string email, string skname);

        public List<Models.Skill> GetSkill(string email);
    }
}
