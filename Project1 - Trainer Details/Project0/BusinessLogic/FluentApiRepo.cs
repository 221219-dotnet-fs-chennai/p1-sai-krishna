
using Data__FluentApi.Entities;

namespace BusinessLogic
{

    public class FluentApiRepo : IFluentApiRepo
    {
        Project0Context context = new Project0Context();

        public void addSkill(Skill s)
        {
            context.Add(s);
            context.SaveChanges();
            Console.WriteLine("skills added");
        }

        public void addTrainer(Trainer trainer)
        {
            context.Trainers.Add(trainer);
        }

        public List<Skill> GetSkil(int id)
        {
           

            var skills = from s in context.Skills
                         where s.TrainerId == id
                         select s;
            return skills.ToList();
        }

        public List<Trainer> GetTrainers()
        {

            
            return context.Trainers.ToList();
        }
    }
}