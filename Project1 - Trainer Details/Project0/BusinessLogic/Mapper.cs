using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi;
using EF=Data__FluentApi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using System.Text.RegularExpressions;

namespace BusinessLogic
{
    public class Mapper
    {
      
        
        
        public static EF.Trainer TrainerMapper(Models.Trainer t)
        {
            return new EF.Trainer()
            {
                
                Email=t.Email,
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

      
        

        public static Models.Trainer TrainerMapper(EF.Trainer t)
        {
            return new Models.Trainer()
            {
                Id = t.TrainerId,
                Email = t.Email,
                Name = t.Name,
                Gender = t.Gender,
                PhoneNo =t.PhoneNo,
                Password = t.Password,
                City = t.City,
                State = t.State,
                Pincode = t.Pincode,
                AboutMe = t.AboutMe

            };
        }

        

        public static List<Models.Trainer> TrainerMapper(List<EF.Trainer> t)
        {
            return t.Select(TrainerMapper).ToList();    
        }
//------------------------------------------------------------------------------------------------------------------------------------------
        public static EF.Skill SkillMapper(Models.Skill s)
        {
            return new EF.Skill()
            {
                TrainerId= s.Id,
                SkillName = s.Name,
                Description= s.Description

            };
        }

        public static Models.Skill SkillMapper(EF.Skill s)
        {
            return new Models.Skill()
            {
                Id=s.TrainerId,
                Name = s.SkillName,
                Description = s.Description

            };
        }

        public static List<Models.Skill> SkillMapper(List<EF.Skill> t)
        {
            return t.Select(SkillMapper).ToList();
        }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static EF.Achivement AchivementMapper(Models.Achivements s)
        {
            return new EF.Achivement()
            {
                TrainerId = s.Id,
                Title = s.Title,
                Description = s.Description

            };
        }

        public static Models.Achivements AchivementMapper(EF.Achivement s)
        {
            return new Models.Achivements()
            {
                Id = s.TrainerId,
                Title = s.Title,
                Description = s.Description

            };
        }

        public static List<Models.Achivements> AchivementMapper(List<EF.Achivement> t)
        {
            return t.Select(AchivementMapper).ToList();
        }

 //------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static EF.Education EducationMapper(Models.Education s)
        {
            return new EF.Education()
            {
                TrainerId = s.Id,
                InstituteName= s.InstituteName,
                Degree= s.Degree,
                StartDate= s.StartDate,
                EndDate= s.EndDate,
                Cgpa=s.Score,

            };
        }

        public static Models.Education EducationMapper(EF.Education s)
        {
            return new Models.Education()
            {
                Id = s.TrainerId,
                InstituteName=s.InstituteName,
                Degree= s.Degree,
                StartDate= s.StartDate,
                EndDate= s.EndDate,
                Score=s.Cgpa,

            };
        }

        public static List<Models.Education> EducationMapper(List<EF.Education> t)
        {
            return t.Select(EducationMapper).ToList();
        }
 //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static EF.Experience ExperienceMapper(Models.Experience s)
        {
            return new EF.Experience()
            {
                TrainerId = s.Id,
                CmpName = s.CompanyName,
                Role = s.Role,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
               

            };
        }

        public static Models.Experience ExperienceMapper(EF.Experience s)
        {
            return new Models.Experience()
            {
                Id = s.TrainerId,
                CompanyName = s.CmpName,
                Role = s.Role,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
              

            };
        }

        public static List<Models.Experience> ExperienceMapper(List<EF.Experience> t)
        {
            return t.Select(ExperienceMapper).ToList();
        }

    }
}
