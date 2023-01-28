using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Data;
using System.Numerics;
using System.Text.RegularExpressions;
using Models;
namespace UI_Console
{
    public class TrainerSignUp
    {
        readonly string connectionString;
        Trainer t=new Trainer();

        public TrainerSignUp(string connectionString) 
        {
            this.connectionString = connectionString;
        }
        public void addNewTrainer()
        {
            TrainerSignIn sin=new TrainerSignIn(connectionString);
            emailCheck:
            Console.WriteLine("Enter your Usrname(email id) or enter 0 to exit");
            string email=Console.ReadLine();
            if (email.Equals("0"))
            {
                
                return;
            }
            else
            {
                t.Email = email;
                if(t.Email.Equals("false"))
                {
                    Console.WriteLine(("Please Enter Correct Email Format"));
                    goto emailCheck;
                }
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();


                string query = $"SELECT Email from Trainer where Email= '{t.Email}' ";

                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();



                if (reader.Read())
                {
                    Console.WriteLine("email already exists, Please SignIn");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Please Enter the following details to Create Your Account:");
                    Console.WriteLine("Enter your password");
                    t.Password = Console.ReadLine();
                    Console.WriteLine("Enter your Name");
                    t.Name = Console.ReadLine();
                    PhoneCheck:
                    Console.WriteLine("Enter your Phone Number");
                    string phone = Console.ReadLine();
                    string pattern = @"^[6-9]\d{9}$";
                    var IsPhoneCorrect = Regex.IsMatch(phone, pattern);
                    if (IsPhoneCorrect)
                        t.PhoneNo = phone;
                    else
                    {
                        Console.WriteLine("Please Check Phone Number and enter a 10 Digit Number only.");
                        goto PhoneCheck;
                    }
                    reader.Close();
                    //using SqlConnection con1 = new SqlConnection(connectionString);
                    //con.Open();
                    query = $"INSERT into Trainer (Name,Email,Password,Phone_no)VALUES('{t.Name}','{t.Email}','{t.Password}','{t.PhoneNo}');";

                    command = new SqlCommand(query, con);
                    int n = command.ExecuteNonQuery();
                    con.Close();
                    Log.Information("New User Account created");
                    Console.WriteLine((n == 1) ? ("Account Created Succesfully,Please SignIn and add Additional Details") : ("Accoumt Could not be Created try again"));
                    Console.ReadKey();
                    return;

                }
            }


        }

    }
}
