using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;



namespace Data
{
    public class skillTable : IchildSql
    {
        //using SqlConnection con=new SqlConnection(string connectionString);
        string connectionString;
        SqlConnection con1;
        
        public skillTable(string connectionString)
        {
            this.connectionString = connectionString;
            con1 = new SqlConnection(connectionString);
            
        }
        public void add(int id)
        {
            Skill s = new Skill();
            Console.WriteLine("Enter Your Skill Name");
            s.Name=Console.ReadLine();
            Console.WriteLine("Enter Description about your Skill");
            s.Description = Console.ReadLine();
            con1.Open();
            string query = $"Insert into Skills (Trainer_id,Skill_name,Description) VALUES({id},'{s.Name}','{s.Description}')";
            SqlCommand command = new SqlCommand(query, con1);
            int n=command.ExecuteNonQuery();
            if(n==1)Console.WriteLine("Skill Added Click any key to continue");
            Console.ReadKey();
            con1.Close();

        }

        public void delete(int id)
        {
            Skill s = new Skill();
            view(id);
            string skname;
            Console.WriteLine("Enter the Skill Name you want to Delete");
            skname = Console.ReadLine();
            con1.Open();
            string query = $"Delete from Skills where Trainer_id={id} AND  Skill_name='{skname}'";
            SqlCommand command=new SqlCommand(query, con1);
            int n=command.ExecuteNonQuery();
            if (n == 1)
            {
                Console.WriteLine($"Skill deleted Click any key to continue");
            }
            else
            {
                Console.WriteLine("Wrong Skill name");
            }

        }

        public void update(int id)
        {
            Skill s = new Skill();
            view(id);
            string skname;
            Console.WriteLine("Enter the skill you want to update");
            skname = Console.ReadLine();
            con1.Open();
            string query = $"Select * from Skills where Trainer_id={id} AND  Skill_name='{skname}'";
            bool repeat = true;
            
            SqlCommand command = new SqlCommand(query, con1);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                s.Name = reader.GetString(1);
                s.Description = reader.GetString(2);
                repeat = true;
            }
            else
            {
                Console.WriteLine("Skill Does not Exist");
                repeat = false;
            }
            con1.Close();
            reader.Close();
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Update Skills");
                Console.WriteLine("[1] Skill Name - " + s.Name);
                Console.WriteLine("[2] Description - " + s.Description);
                Console.WriteLine("[3] Save");
                Console.WriteLine("[0] bo back");
                Console.WriteLine("Enter Your Choice");
                int userchoice = Convert.ToInt32(Console.ReadLine());

                switch (userchoice)
                {
                    case 0:
                        repeat = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter Skill name");
                        s.Name = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Description");
                        s.Description = Console.ReadLine();
                        break;
                    case 3:
                        con1.Open();
                        string query1 = $"Update Skills set Skill_name='{s.Name}',Description='{s.Description}'  where  Skill_name='{skname}' AND Trainer_id={id};";
                        SqlCommand command1= new SqlCommand(query1, con1);
                        int n=command1.ExecuteNonQuery();
                        //Console.WriteLine($"Skill updated click any key to continue");
                        if (n == 1) 
                        {
                            Console.WriteLine($"Skill updated click any key to continue");
                         }
                   
                        con1.Close();
                        repeat= false;
                        break;

                }
            }
        }

        public void view(int id)
        {
            Skill s = new Skill();
            con1.Open();
            string query = $"Select * from Skills where Trainer_id={id}";
            SqlCommand command = new SqlCommand(query, con1);
            SqlDataReader reader=command.ExecuteReader();
            Console.WriteLine("============================Skills Present=======================\n");
            while(reader.Read()) 
            {
                s.Name=reader.GetString(1);
                s.Description=reader.GetString(2);
                Console.WriteLine($"-> {s.Name}{new string(' ',25-(s.Name.Length))}-{s.Description}\n");

            }
            con1.Close();
            reader.Close();
             
        }
    }
}
