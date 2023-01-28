using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Models;
using BusinessLogic;

namespace Data
{
    public class trainerTable : ISqlRepo
    {

        string connectionString;
        IFluentApiRepo fr = new FluentApiRepo();
        

        public trainerTable(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void display1(Trainer trainer)
        {
            
            Console.WriteLine("Enter Additional Trainer information");
            Console.WriteLine(" Email - " + trainer.Email);
            //Console.WriteLine(" Phone - " + trainer.PhoneNo);
            //Console.WriteLine(" Name - " + trainer.Name);
            Console.WriteLine("[1] Gender - " + trainer.Gender);
            Console.WriteLine("[2] City -" + trainer.City);
            Console.WriteLine("[3] State - " + trainer.State);
            Console.WriteLine("[4] Pincode - " + trainer.Pincode);
            Console.WriteLine("[5] Brief about Yourself - " + trainer.AboutMe);
            Console.WriteLine("[6] Save");
            Console.WriteLine("[0] Go Back");
            

        }
        

        public void addData(Trainer trainer) { 
            
            
            bool repeat = true;
            while (repeat == true)
            {
                Console.Clear();
                display1(trainer);
                Console.WriteLine("Enter Your Choice");
                int userchoice = Convert.ToInt32(Console.ReadLine());

                switch (userchoice)
                {
                    case 0:
                        repeat= false;
                        break;
                    case 1:
                        Console.WriteLine("Enter Your Gender(M/F)");
                        trainer.Gender=Console.ReadLine();
                        if (trainer.Gender.Equals("false"))
                        {
                            Console.WriteLine(("Please Enter Correct Gender(M/F)"));
                            goto case 1;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter Your City"); 
                        trainer.City = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter Your State");
                        trainer.State = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter Your Pincode");
                        trainer.Pincode = Console.ReadLine();
                        if (trainer.Pincode.Equals("false"))
                        {
                            Console.WriteLine(("Please Enter Correct Pincode with 6 Digits"));
                            goto case 4;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter a brief about Yourself");
                        trainer.AboutMe = Console.ReadLine();
                        break;
                    case 6:
                        {

                            //var trai=Mapper.TrainerMapper(trainer);
                            //fr.addTrainer(trai);
                            using SqlConnection con1 = new SqlConnection(connectionString);
                            con1.Open();

                            string query = $"UPDATE Trainer SET Gender='{trainer.Gender}', City='{trainer.City}', State='{trainer.State}', Pincode='{trainer.Pincode}' ,About_me='{trainer.AboutMe}'WHERE Email='{trainer.Email}';";

                            SqlCommand command = new SqlCommand(query, con1);
                            int n = command.ExecuteNonQuery();
                            if (n == 1)
                            {

                                Console.WriteLine("Details Added Click any key to continue");

                            }
                            repeat = false;
                        }
                        break;

                }
            }
            
        }
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public Trainer getData(Trainer t)
        {
            string username = t.Email;
            Trainer trainer = new Trainer();
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            string query = $"SELECT * from Trainer where Email='{username}'";

            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                trainer.Id = reader.GetInt32(0);
                trainer.Name = reader.GetString(1);
                trainer.Gender = reader.GetString(2);
                trainer.PhoneNo = reader.GetString(3);
                trainer.Email = reader.GetString(4);
                trainer.Password = reader.GetString(5);
                trainer.City = reader.GetString(6);
                trainer.State = reader.GetString(7);
                trainer.Pincode = reader.GetString(8);
                trainer.AboutMe= reader.GetString(9);
                //Console.WriteLine(trainer.ToString());


            }
           // Console.WriteLine(trainer.ToString());
           return trainer;
            

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void display2(Trainer trainer)
        {

            Console.WriteLine("Change Trainer details");
            Console.WriteLine(" Email - " + trainer.Email);
            Console.WriteLine("[1] Password - " + trainer.Password);
            Console.WriteLine("[2] Phone - " + trainer.PhoneNo);
            Console.WriteLine("[3] Name - " + trainer.Name);
            Console.WriteLine("[4] Gender - " + trainer.Gender);
            Console.WriteLine("[5] City -" + trainer.City);
            Console.WriteLine("[6] State - " + trainer.State);
            Console.WriteLine("[7] Pincode - " + trainer.Pincode);
            Console.WriteLine("[8] Brief about Yourself - " + trainer.AboutMe);
            Console.WriteLine("[9] Save");
            Console.WriteLine("[0] Go Back");


        }



        public void updateData(Trainer trainer)
        {

            trainer = getData(trainer);
            bool repeat = true;
            while (repeat == true)
            {
                Console.Clear();
                display2(trainer);
                Console.WriteLine("Enter Your Choice to update that field");
                int userchoice = Convert.ToInt32(Console.ReadLine());

                switch (userchoice)
                {
                    case 0:
                        repeat = false;
                        break;
                    case 1:
                        Console.WriteLine("Enter Your New Password");
                        trainer.PhoneNo = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter Your Phone Number");
                        trainer.PhoneNo = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Eneter Your Name");
                        trainer.Name = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter Your Gender(M/F)");
                        trainer.Gender = Console.ReadLine();
                        if (trainer.Gender.Equals("false"))
                        {
                            Console.WriteLine(("Please Enter Correct Gender(M/F)"));
                            goto case 4;
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter Your City");
                        trainer.City = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Enter Your State");
                        trainer.State = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Enter Your Pincode");
                        trainer.Pincode = Console.ReadLine();
                        if (trainer.Pincode.Equals("false"))
                        {
                            Console.WriteLine(("Please Enter Correct Pincode with 6 Digits"));
                            goto case 7;
                        }
                        break;
                    case 8:
                        Console.WriteLine("Enter a brief about Yourself");
                        trainer.AboutMe = Console.ReadLine();
                        break;
                    case 9:
                        {
                            using SqlConnection con1 = new SqlConnection(connectionString);
                            con1.Open();

                            string query = $"UPDATE Trainer SET Gender='{trainer.Gender}', City='{trainer.City}', State='{trainer.State}', Pincode='{trainer.Pincode}' ,About_me='{trainer.AboutMe}'WHERE Email='{trainer.Email}';";

                            SqlCommand command = new SqlCommand(query, con1);
                            int n = command.ExecuteNonQuery();
                            Console.WriteLine("Details Updated Click any key to continue");
                          
                            repeat = false;
                        }
                        break;

                }
            }

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public bool deleteData(Trainer trainer)
        {
            Console.WriteLine("Data present");
           
            Trainer t = getData(trainer);
            Console.WriteLine(t.ToString());
            using SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            Console.WriteLine("Click 'Yes' to confirm 'No' to Exit");
            string conf=Console.ReadLine();
            string query = $"DELETE from Trainer where Email='{t.Email}'";
            SqlCommand command = new SqlCommand(query, con);
            if (conf.Equals("Yes"))
            {
                int n=command.ExecuteNonQuery();
                Console.WriteLine($"Your Account was deleted Successfully Click any key to continue");
               
                return true;
            }
            else {
                return false;           
            }

        }
    }
}
