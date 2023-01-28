using Data__FluentApi.Entities;
namespace Data__FluentApi
{
    public  class FluentMethods
    {
        public static List<Trainer> GetTrainers() 
        { 
            Project0Context context= new Project0Context();
            return context.Trainers.ToList();
        }

        public static List<Skill> GetSkils(int id)
        {
            Project0Context context = new Project0Context();
           
            var skills = from s in context.Skills
                         where s.TrainerId==id
                         select s;
            return skills.ToList();
        }

    }
}