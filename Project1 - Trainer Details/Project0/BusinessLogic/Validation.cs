using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data__FluentApi.Entities;

namespace BusinessLogic
{
    public class Validation
    {
        static Project0Context context = new Project0Context();
        public static int IdByEmail(string email)
        {
            var row= context.Trainers.Where(id => id.Email == email).First();
            return row.TrainerId;
        }
    }
}
