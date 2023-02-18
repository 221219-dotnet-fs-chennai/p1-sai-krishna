
using System.Xml.Linq;
using Data__FluentApi;
using Data__FluentApi.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace BusinessLogic
{

    public class logic : ITrainerLogic,ISkillLogic,IAchivemensLogic,IEducationLogic,IExperienceLogic
    {
        Validation v;
        TrainerContext context;
        ITrainerRepo ef;
        ISkillRepo efs;
        IAchivementsRepo efa;
        IEducationRepo efe;
        IExperienceRepo efex;

        public logic(ITrainerRepo _ef, ISkillRepo efs,IAchivementsRepo _efa ,IEducationRepo _efe,IExperienceRepo _efex,Validation _v, TrainerContext _context)
        {
            ef = _ef;
            this.efs = efs;
            efa = _efa;
            efe = _efe;
            efex = _efex;
            v= _v;
            context = _context;
        }
       


        public Models.Trainer addTrainer(Models.Trainer trainer)
        {
            trainer.Email = RegexValidation.isValidEmail(trainer.Email) ? trainer.Email : throw new UserDefinedException("Invalid email format");
            trainer.Password = RegexValidation.isValidPassword(trainer.Password) ? trainer.Password : throw new UserDefinedException("enter Password of length 8-20 with at lest 1 Uppercase Letter,1 number");
            trainer.PhoneNo= RegexValidation.isValidPhone(trainer.PhoneNo)? trainer.PhoneNo : throw new UserDefinedException("Enter Phone with 10 digits");
            trainer.Gender = RegexValidation.isValidGender(trainer.Gender) ? trainer.Gender : throw new UserDefinedException("Enter M/F");
            trainer.Pincode = RegexValidation.isValidZipcode(trainer.Pincode) ? trainer.Pincode : throw new UserDefinedException("Invalid Pincode format");
            return(Mapper.TrainerMapper(ef.addTrainer(Mapper.TrainerMapper(trainer))));
        }

        public Models.Trainer GetTrainer(string email)
        {
            int id = v.IdByEmail(email);
            return  Mapper.TrainerMapper(ef.GetTrainer(id));
            
        }
       

       
        public Models.Trainer updateTrainer(string email,Models.Trainer trainer)
        {
            var t = v.trainerByEmail(email);
            t.Name = trainer.Name;
            t.Password = RegexValidation.isValidPassword(trainer.Password) ? trainer.Password : throw new UserDefinedException("Invalid email format");
            t.PhoneNo = RegexValidation.isValidPhone(trainer.PhoneNo) ? trainer.PhoneNo : throw new UserDefinedException("Enter Phone with 10 digits");
            t.Gender = RegexValidation.isValidGender(trainer.Gender) ? trainer.Gender : throw new UserDefinedException("Enter M/F");
            t.City = trainer.City;
            t.State = trainer.State;
            t.Pincode = RegexValidation.isValidZipcode(trainer.Pincode) ? trainer.Pincode : throw new UserDefinedException("Invalid pincode format");
            t.AboutMe = trainer.AboutMe;

           
            return (Mapper.TrainerMapper(ef.updateTrainer(t)));
        }

        

        public Models.Trainer deleteTrainer(string email)
        {
            var t = v.trainerByEmail(email);
            return (Mapper.TrainerMapper(ef.deleteTrainer(t)));
        }



//-----------------------------------------------------------------------------------------------------------------------------------------------------------
        public Models.Skill addSkill(string email, Models.Skill s)
        {
            s.Id = v.IdByEmail(email);
            return Mapper.SkillMapper(efs.addSkill(Mapper.SkillMapper(s)));
        }

        public Models.Skill updateSkill(string email, string skName, Models.Skill s)
        {
            var skillToUpdate = v.skillByName(v.IdByEmail(email), skName);
            skillToUpdate.SkillName = s.Name;
            skillToUpdate.Description = s.Description;
            return Mapper.SkillMapper(efs.updateSkill(skillToUpdate));
        }

        public Models.Skill deleteSkill(string email, string skname)
        {
            var skillToDelete = v.skillByName(v.IdByEmail(email), skname);
            return Mapper.SkillMapper(efs.removeSkill(skillToDelete));
        }

        public List<Models.Skill> GetSkill(string email)
        {
            int id = v.IdByEmail(email);
            return Mapper.SkillMapper(efs.GetSkil(id));
        }

//--------------------------------------------------------------------------------------------------------------------------------------------------------------

        public Achivements addAchivement(string email, Achivements a)
        {
            a.Id = v.IdByEmail(email);
            return Mapper.AchivementMapper(efa.addAchivement(Mapper.AchivementMapper(a)));
        }

        public Achivements updateAchivement(string email, string title, Models.Achivements a)
        {
            var achToUpdate = v.achivementByTitle(v.IdByEmail(email), title);
            achToUpdate.Title = a.Title;
            achToUpdate.Description = a.Description;
            return Mapper.AchivementMapper(efa.updateAchivement(achToUpdate));
        }

        public Achivements deleteAchivement(string email, string achname)
        {
            var achToDelete = v.achivementByTitle(v.IdByEmail(email), achname);
            return Mapper.AchivementMapper(efa.removeAchivement(achToDelete));
        }

        public List<Achivements> getAchivements(string email)
        {
            int id = v.IdByEmail(email);
            return Mapper.AchivementMapper(efa.GeAchivement(id));
        }
//-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public Models.Education addEducation(string email, Models.Education e)
        {
            e.Id = v.IdByEmail(email);
            e.StartDate = RegexValidation.isValidStartDate(e.StartDate) ? e.StartDate : throw new UserDefinedException("Please enter in correct format(MM/YYYY)");
            e.EndDate = RegexValidation.isValidEndDate(e.EndDate) ? e.EndDate : throw new UserDefinedException("Please enter in correct format(MM/YYYY) or 'Present'");
            return Mapper.EducationMapper(efe.addEducation(Mapper.EducationMapper(e)));
        }

        public Models.Education updateEducation(string email, string eduName, Models.Education e)
        {
            var eduToUpdate = v.educationByName(v.IdByEmail(email), eduName);
            eduToUpdate.InstituteName = e.InstituteName;
            eduToUpdate.Degree = e.Degree;
            eduToUpdate.StartDate = RegexValidation.isValidStartDate(e.StartDate) ? e.StartDate : throw new UserDefinedException("Please enter in correct format(MM/YYYY)");
            eduToUpdate.EndDate = RegexValidation.isValidEndDate(e.EndDate) ? e.EndDate : throw new UserDefinedException("Please enter in correct format(MM/YYYY) or 'Present'");
            eduToUpdate.Cgpa = e.Score;
            return Mapper.EducationMapper(efe.updateEducation(eduToUpdate));
        }

        public Models.Education deleteEducation(string email, string eduname)
        {
            var eduToDelete = v.educationByName(v.IdByEmail(email), eduname);
            return Mapper.EducationMapper(efe.removeEducation(eduToDelete));
        }

        public List<Models.Education> GetEducation(string email)
        {
            int id = v.IdByEmail(email);
            return Mapper.EducationMapper(efe.GeEducation(id));
        }


        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        public Models.Experience addExperience(string email, Models.Experience ex)
        {
            ex.Id = v.IdByEmail(email);
            ex.StartDate = RegexValidation.isValidStartDate(ex.StartDate) ? ex.StartDate : throw new UserDefinedException("Please enter in correct format(MM/YYYY)");
            ex.StartDate = RegexValidation.isValidEndDate(ex.StartDate) ? ex.StartDate : throw new UserDefinedException("Please enter in correct format(MM/YYYY) or 'Present'");
            return Mapper.ExperienceMapper(efex.addExperience(Mapper.ExperienceMapper(ex)));
        }

        public Models.Experience updateExperience(string email, string exName, Models.Experience ex)
        {
            var exToUpdate = v.experienceByName(v.IdByEmail(email), exName);
            exToUpdate.CmpName = ex.CompanyName;
            exToUpdate.Role = ex.Role;
            exToUpdate.StartDate = RegexValidation.isValidStartDate(ex.StartDate) ? ex.StartDate : throw new UserDefinedException("Please enter in correct format(MM/YYYY)");
            exToUpdate.EndDate = RegexValidation.isValidEndDate(ex.EndDate) ? ex.EndDate : throw new UserDefinedException("Please enter in correct format(MM/YYYY) or 'Present'");

            return Mapper.ExperienceMapper(efex.updateExperience(exToUpdate));
        }

        public Models.Experience deleteExperience(string email, string exName)
        {
            var exToDelete = v.experienceByName(v.IdByEmail(email), exName);
            return Mapper.ExperienceMapper(efex.removeExperience(exToDelete));
        }

        public List<Models.Experience> GetExperience(string email)
        {
            int id = v.IdByEmail(email);
            return Mapper.ExperienceMapper(efex.GeExperience(id));
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    }

 




}
