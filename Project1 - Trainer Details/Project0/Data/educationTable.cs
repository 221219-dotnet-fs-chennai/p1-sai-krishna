using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;


namespace Data
{
    public class educationTable : IchildSql
    {
        string connectionString;
        SqlConnection con1;
        public educationTable(string connectionString)
        {
            this.connectionString = connectionString;
            con1 = new SqlConnection(connectionString);

        }
        public void add(int id)
        {
            Education e=new Education();
            Console.WriteLine("Enter your Institute Name");
            e.InstituteName = Console.ReadLine();
            Console.WriteLine("Enter your Degree");
            e.Degree = Console.ReadLine();
            
        checkSDate:
            Console.WriteLine("Enter your Start Date in (MM/YYYY) format");
            e.StartDate = Console.ReadLine();
            if (e.StartDate.Equals("false"))
            {
                Console.WriteLine("Wrong date format entered,try again");
                goto checkSDate;
            }
        checkEDate:
            Console.WriteLine("Enter your End Date in (MM/YYYY) format or 'Present' if currenty Studying there");
            e.EndDate = Console.ReadLine();
            if (e.EndDate.Equals("false"))
            {
                Console.WriteLine("Wrong date format entered,try again");
                goto checkEDate;
            }
            Console.WriteLine("Enter your CGPA/Percentage");
            e.Score = Console.ReadLine();
            con1.Open();
            string query = $"Insert into Education (Trainer_id,Institute_name,Degree,Start_date,End_date,CGPA) VALUES({id},'{e.InstituteName}','{e.Degree}','{e.StartDate}','{e.EndDate}','{e.Score}')";
            SqlCommand command = new SqlCommand(query, con1);
            int n = command.ExecuteNonQuery();
            if(n==1)Console.WriteLine("Education added Click any key to continue");
            con1.Close();
        }

        public void delete(int id)
        {
            Education e=new Education();
            view(id);
            string eduname;
            Console.WriteLine("Enter the Education Institue name  you want to Delete");
            eduname = Console.ReadLine();
            con1.Open();
            string query = $"Delete from Education where Trainer_id={id} AND  Institute_name='{eduname}'";
            SqlCommand command = new SqlCommand(query, con1);
            int n = command.ExecuteNonQuery();
            if (n == 1)
            {
                Console.WriteLine($"Education Details deleted Click any key to continue");
            }
            else
            {
                Console.WriteLine("Wrong Institute name");
            }
        }

        public void update(int id)
        {
            Education e=new Education();
            view(id);
            string eduname;
            Console.WriteLine("Enter the Institute Name for which Education Details you want to update");
            eduname = Console.ReadLine();
            con1.Open();
            string query = $"Select * from Education where Trainer_id={id} AND  Institute_name='{eduname}'";
            bool repeat = true;

            SqlCommand command = new SqlCommand(query, con1);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                e.InstituteName = reader.GetString(1);
                e.Degree = reader.GetString(2);
                e.StartDate = reader.GetString(3);
                e.EndDate = reader.GetString(4);
                e.Score= reader.GetString(5);
                repeat = true;
            }
            else
            {
                Console.WriteLine("Institute Name Does not Exist in Your Profile");
                repeat = false;
            }
            con1.Close();
            reader.Close();
            while (repeat)
            {
                Console.Clear();
                Console.WriteLine("Update Education details");
                Console.WriteLine("[1] Institute Name - " + e.InstituteName);
                Console.WriteLine("[2] Degree - " + e.Degree);
                Console.WriteLine("[3] Start Date - "+ e.StartDate);
                Console.WriteLine("[4] End Date - "+e.EndDate);
                Console.WriteLine("[5] Score - "+e.Score);
                Console.WriteLine("[6] Save");
                Console.WriteLine("[0] bo back");
                Console.WriteLine("Enter Your Choice");
                int userchoice = Convert.ToInt32(Console.ReadLine());

                switch (userchoice)
                {
                    case 0:
                        repeat = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter Institute name");
                        e.InstituteName = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Your Degree");
                        e.Degree = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter Start Date(MM/YYYY)");
                        e.StartDate = Console.ReadLine();
                        if (e.StartDate.Equals("false"))
                        {
                            Console.WriteLine("Wrong date format entered,try again");
                            goto case 3;
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter End Date(MM/YYYY)");
                        e.EndDate = Console.ReadLine();
                        if (e.EndDate.Equals("false"))
                        {
                            Console.WriteLine("Wrong date format entered,try again");
                            goto case 4;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter Your Score");
                        e.Score = Console.ReadLine();
                        break;
                    case 6:
                        con1.Open();
                        string query1 = $"Update Education set Institute_name='{e.InstituteName}',Degree='{e.Degree}',Start_date='{e.StartDate}',End_date='{e.EndDate}',CGPA='{e.Score}'  where  Institute_name='{eduname}' AND Trainer_id={id};";
                        SqlCommand command1 = new SqlCommand(query1, con1);
                        int n = command1.ExecuteNonQuery();
                        if (n == 1)
                            Console.WriteLine($"Education updated click any key to continue");
                        
                        con1.Close();
                        repeat = false;
                        break;

                }
            }
        }

        public void view(int id)
        {
            Education e= new Education();
            con1.Open();
            string query = $"Select * from Education where Trainer_id={id}";
            SqlCommand command = new SqlCommand(query, con1);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("==========================Education Details=======================\n");
            
            while (reader.Read())
            {
                e.InstituteName = reader.GetString(1);
                e.Degree = reader.GetString(2);
                e.StartDate = reader.GetString(3);
                e.EndDate = reader.GetString(4);
                e.Score= reader.GetString(5);
                Console.WriteLine($"-> {e.Degree}\n   {e.InstituteName}\n   Percentage/Score - {e.Score}\n   {e.StartDate}-{e.EndDate}\n");
            }
            con1.Close();
            reader.Close();
            
        }
    }
}
