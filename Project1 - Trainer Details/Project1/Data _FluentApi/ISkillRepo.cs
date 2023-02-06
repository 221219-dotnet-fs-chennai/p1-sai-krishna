using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace Data__FluentApi
{
    public interface ISkillRepo
    {
        public Skill addSkill(Skill s);

        public Skill updateSkill(Skill s);
        public Skill removeSkill(Skill s);

        public List<Skill> GetSkil(int id);
    }
}
