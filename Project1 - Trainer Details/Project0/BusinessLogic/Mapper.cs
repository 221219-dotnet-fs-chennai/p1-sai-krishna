using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi;
using EF=Data__FluentApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;

namespace BusinessLogic
{
    public class Mapper
    {
        public static EF.Trainer TrainerMapper(Models.Trainer t)
        {
            return new EF.Trainer()
            {
                TrainerId = t.Id,
                Email= t.Email,
                Name= t.Name,
                Gender= t.Gender,
                PhoneNo= t.PhoneNo, 
                Password= t.Password,
                City= t.City,
                State= t.State,
                Pincode= t.Pincode,
                AboutMe= t.AboutMe

            };
        }

        public static EF.Skill SkillMapper(Models.Skill s)
        {
            return new EF.Skill()
            {
                TrainerId= s.Id,
                SkillName = s.Name,
                Description= s.Description

            };
        }
    }
}
