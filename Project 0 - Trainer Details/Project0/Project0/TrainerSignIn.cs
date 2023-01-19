using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;


namespace Project0
{
    public class TrainerSignIn
    {
        readonly string connectionString;
        Trainer t = new Trainer();

        public TrainerSignIn(string connectionString)
        {
            this.connectionString = connectionString;
        }
        /// <summary>
        /// To validate Trainer Log In Credentials
        /// </summary>
        /// <returns></returns>
        public Trainer Validate()
        {
        
            Console.WriteLine("Enter your Email Id");
            t.Email = Console.ReadLine();
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            string query = $"SELECT Email from Trainer where Email= '{t.Email}' ";

            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();



            if (reader.Read())
            {
                Passwordchek:
                Console.WriteLine("Enter your password to SignIn or 0 to Exit");
                string Password = Console.ReadLine();
                if (Password.Equals("0"))
                {
                    t.Login = false;
                }
                else
                {
                    query = $"SELECT trainer_id,Password from Trainer where Email= '{t.Email}' ";

                    command = new SqlCommand(query, con);
                    reader.Close();
                    SqlDataReader reader1 = command.ExecuteReader();
                    if (reader1.Read())
                    {
                        string passCheck = reader1.GetString(1);
                        //Console.WriteLine(passCheck);
                        if (passCheck == Password)
                        {
                            Console.WriteLine("SignIn Successful Click any key to contiue.");
                            t.Id = reader1.GetInt32(0);
                            t.Login = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Wrong Password Entered try again");
                            reader1.Close();
                            goto Passwordchek;
                        }
                    }
                }


            }
            else
            {
                Console.WriteLine("email Does not exist, Please or SignUp");
                //Validate();
                //sup.addNewTrainer();
                t.Login= false;
                Console.ReadKey();

            }
            return t;
        }
    }
}

