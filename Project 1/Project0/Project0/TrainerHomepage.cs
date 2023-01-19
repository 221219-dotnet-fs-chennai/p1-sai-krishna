//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Data;

//namespace Project0
//{
//    public class TrainerHomepage
//    {
//        public static void Tmenu()
//        {

//            Trainer t = new Trainer();
//            TrainerSignUp s = new TrainerSignUp(File.ReadAllText("../../../ConnectionString.txt"));
//            TrainerSignIn sin = new TrainerSignIn(File.ReadAllText("../../../ConnectionString.txt"));

//            ISqlRepo r = new trainerTable(File.ReadAllText("../../../ConnectionString.txt"));
//            bool repeat = true;

//        ExceptionConn:
//            try
//            {
//                while (repeat)
//                {
//                    Console.Clear();
//                    Console.WriteLine("Enter [1] to SignUp");
//                    Console.WriteLine("Enter [2] to SignIn");
//                    Console.WriteLine("Enter [0] to Exit");
//                    int choice = Convert.ToInt32(Console.ReadLine());
//                    switch (choice)
//                    {
//                        case 1:
//                            s.addNewTrainer();
//                            break;
//                        case 2:
//                            t = sin.Validate();
//                            if (t.Login == true)
//                            {
//                                Log.Information("USer Logged In Successfully");
//                                TrainerOperationMenu us = new TrainerOperationMenu(t);
//                                us.LoginMenu();
//                            }
//                            break;
//                        case 0:
//                            repeat = false;
//                            break;
//                        default:
//                            Console.WriteLine("Please Choose the Right option");
//                            Console.ReadKey();
//                            break;
//                    }
//                }
//            }
//            catch (System.Data.SqlClient.SqlException ex)
//            {
//                Console.WriteLine(ex.Message);
//                Console.WriteLine("Please Check Your Internet Connection");
//                Console.ReadKey();
//                goto ExceptionConn;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message + "Please Try Again");
//                Console.ReadKey();
//                goto ExceptionConn;
//            }
//        }


//    }
//}
