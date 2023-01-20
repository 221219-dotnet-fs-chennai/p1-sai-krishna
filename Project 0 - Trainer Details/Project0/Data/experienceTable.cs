using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class experienceTable : IchildSql
    {
        string connectionString;
        SqlConnection con1;
        public experienceTable(string connectionString)
        {
            this.connectionString = connectionString;
            con1 = new SqlConnection(connectionString);

        }
        public void add(int id)
        {
            Experience ex = new Experience();
            Console.WriteLine("Enter your Company Name");
            ex.CompanyName = Console.ReadLine();
            Console.WriteLine("Enter your Role");
            ex.Role = Console.ReadLine();
    checkSDate:
            Console.WriteLine("Enter your Start Date in (MM/YYYY) format");
            ex.StartDate = Console.ReadLine();
            if (ex.StartDate.Equals("false"))
            {
                Console.WriteLine("Wrong date format entered,try again");
                goto checkSDate;
            }
   checkEDate:
            Console.WriteLine("Enter your End Date in (MM/YYYY) format or 'Present' if currenty working there");
            ex.EndDate = Console.ReadLine();
            if (ex.EndDate.Equals("false"))
            {
                Console.WriteLine("Wrong date format entered,try again");
                goto checkEDate;
            }
            con1.Open();
            string query = $"Insert into Experience (Trainer_id,Cmp_name,Role,Start_date,End_date) VALUES({id},'{ex.CompanyName}','{ex.Role}','{ex.StartDate}','{ex.EndDate}')";
            SqlCommand command = new SqlCommand(query, con1);
            int n = command.ExecuteNonQuery();
            if (n == 1)
                Console.WriteLine("Experience Added Click any key to continue");
            con1.Close();
        }

        public void delete(int id)
        {
            Experience ex = new Experience();
            view(id);
            string cmpname;
            Console.WriteLine("Enter the Company name  you want to Delete");
            cmpname = Console.ReadLine();
            con1.Open();
            string query = $"Delete from Experience where Trainer_id={id} AND  Cmp_name='{cmpname}'";
            SqlCommand command = new SqlCommand(query, con1);
            int n = command.ExecuteNonQuery();
            if (n == 1)
            {
                Console.WriteLine($"Experience deleted Click any key to continue");
            }
            else
            {
                Console.WriteLine("Wrong Company name");
            }
        }

        public void update(int id)
        {
            Experience ex = new Experience();
            view(id);
            string cmpname;
            Console.WriteLine("Enter the Company Name form which Experience Details you want to update");
            cmpname = Console.ReadLine();
            con1.Open();
            string query = $"Select * from Experience where Trainer_id={id} AND  Cmp_name='{cmpname}'";
            bool repeat = true;

            SqlCommand command = new SqlCommand(query, con1);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ex.CompanyName = reader.GetString(1);
                ex.Role = reader.GetString(2);
                ex.StartDate = reader.GetString(3);
                ex.EndDate = reader.GetString(4);
                repeat = true;
            }
            else
            {
                Console.WriteLine("Company Name Does not Exist in Your Profile");
                repeat = false;
                Console.ReadKey();
                //return;
            }
            con1.Close();
            reader.Close();
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Update Experience Details");
                Console.WriteLine("[1] Company Name - " + ex.CompanyName);
                Console.WriteLine("[2] Role - " + ex.Role);
                Console.WriteLine("[3] Start Date - " + ex.StartDate);
                Console.WriteLine("[4] End Date - " + ex.EndDate);
                Console.WriteLine("[5] Save");
                Console.WriteLine("[0] bo back");
                Console.WriteLine("Enter Your Choice");
                int userchoice = Convert.ToInt32(Console.ReadLine());

                switch (userchoice)
                {
                    case 0:
                        repeat = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter Company Name");
                        ex.CompanyName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Your Role");
                        ex.Role = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter Start Date(MM/YYYY)");
                        ex.StartDate = Console.ReadLine();
                        if (ex.StartDate.Equals("false"))
                        {
                            Console.WriteLine("Wrong date format entered,try again");
                            goto case 3;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter End Date(MM/YYYY)");
                        ex.EndDate = Console.ReadLine();
                        if (ex.EndDate.Equals("false"))
                        {
                            Console.WriteLine("Wrong date format entered,try again");
                            goto case 4;
                        }
                        break;
                   case 5:
                        con1.Open();
                        string query1 = $"Update Experience set Cmp_name='{ex.CompanyName}',Role='{ex.Role}',Start_date='{ex.StartDate}',End_date='{ex.EndDate}'  where  Cmp_name='{cmpname}';";
                        SqlCommand command1 = new SqlCommand(query1, con1);
                        int n = command1.ExecuteNonQuery();
                        if (n == 1)
                            Console.WriteLine($"Experience Deteils updated click any key to continue");
                        
                        con1.Close();
                        repeat = false;
                        break;

                }
            }
        }

        public void view(int id)
        {
            Experience ex = new Experience();
            con1.Open();
            string query = $"Select * from Experience where Trainer_id={id}";
            SqlCommand command = new SqlCommand(query, con1);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("=============================Experiences=========================\n");
            while (reader.Read())
            {
                ex.CompanyName = reader.GetString(1);
                ex.Role = reader.GetString(2);
                ex.StartDate = reader.GetString(3);
                ex.EndDate = reader.GetString(4);
          
                Console.WriteLine($"-> {ex.Role}, {ex.CompanyName}\n   {ex.StartDate} - {ex.EndDate}\n");
            }
            con1.Close();
            reader.Close();
            
        }
    }
}
