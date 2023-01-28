using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace Data
{
    public class achivementsTable : IchildSql
    {
        string connectionString;
        SqlConnection con1;

        public achivementsTable(string connectionString)
        {
            this.connectionString = connectionString;
            con1 = new SqlConnection(connectionString);

        }
        public void add(int id)
        {
            Achivements a = new Achivements();
            Console.WriteLine("Enter Your Achivement/Certicate Title");
            a.Title = Console.ReadLine();
            Console.WriteLine("Enter Description about your Achivement/Cetificate");
            a.Description = Console.ReadLine();
            con1.Open();
            string query = $"Insert into Achivements (Trainer_id,Title,Description) VALUES({id},'{a.Title}','{a.Description}')";
            SqlCommand command = new SqlCommand(query, con1);
            int n = command.ExecuteNonQuery();
            if(n==1)Console.WriteLine("Achivement Added Click any key to continue");
            con1.Close();
        }

        public void delete(int id)
        {
            Achivements a=new Achivements();
            view(id);
            string aname;
            Console.WriteLine("Enter the Achivement Title you want to Delete");
            aname = Console.ReadLine();
            con1.Open();
            string query = $"Delete from Achivements where Trainer_id={id} AND  Title='{aname}'";
            SqlCommand command = new SqlCommand(query, con1);
            int n = command.ExecuteNonQuery();
            if (n == 1)
            {
                Console.WriteLine($"Achivement deleted Click any key to continue");
            }
            else
            {
                Console.WriteLine("Wrong Achivement Title");
            }
        }

        public void update(int id)
        {
            Achivements a = new Achivements();
            view(id);
            string aname;
            Console.WriteLine("Enter the Achivement Title you want to update");
            aname = Console.ReadLine();
            con1.Open();
            string query = $"Select * from Achivements where Trainer_id={id} AND  Title='{aname}'";
            bool repeat = true;

            SqlCommand command = new SqlCommand(query, con1);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                a.Title = reader.GetString(1);
                a.Description = reader.GetString(2);
                repeat = true;
            }
            else
            {
                Console.WriteLine("Achivement Does not Exist");
                repeat = false;
            }
            con1.Close();
            reader.Close();
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Update Achivement");
                Console.WriteLine("[1] Title - " + a.Title);
                Console.WriteLine("[2] Description - " + a.Description);
                Console.WriteLine("[3] Save");
                Console.WriteLine("[0] go back");
                Console.WriteLine("Enter Your Choice");
                int userchoice = Convert.ToInt32(Console.ReadLine());

                switch (userchoice)
                {
                    case 0:
                        repeat = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter Achivement Title");
                        a.Title = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Description");
                        a.Description = Console.ReadLine();
                        break;
                    case 3:
                        con1.Open();
                        string query1 = $"Update Achivements set Title='{a.Title}',Description='{a.Description}'  where  Title='{aname}' AND Trainer_id={id}";
                        SqlCommand command1 = new SqlCommand(query1, con1);
                        int n = command1.ExecuteNonQuery();
                        if (n == 1) Console.WriteLine($"Achivement updated click any key to continue");
                        
                        con1.Close();
                        repeat = false;
                        break;

                }
            }
        }

        public void view(int id)
        {
            Achivements a=new Achivements();
            con1.Open();
            string query = $"Select * from Achivements where Trainer_id={id}";
            SqlCommand command = new SqlCommand(query, con1);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("==================Achivements/Certificates Present===============\n");
            
            while (reader.Read())
            {
                a.Title = reader.GetString(1);
                a.Description = reader.GetString(2);
               
                Console.WriteLine($"-> {a.Title}\n   {a.Description}\n");
            }
            con1.Close();
            reader.Close();
            

        }
    }
}
