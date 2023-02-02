using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;
using Data__FluentApi;
using BusinessLogic;

namespace UI_Console
{
    
    public  class TrainerOperationMenu
    {
        string username;
        Trainer t=new Trainer();
        ITrainerLogic bl=new logic();
        
        
        int tid;
        bool accountDeleted=false;
        public TrainerOperationMenu(Trainer t)
        {
            this.username = t.Email;
            this.t = t;
            this.tid = t.Id;
        }
        
        public void LoginMenu() 
        {
            try
            {
                bool repeat = true;
                while (repeat == true)
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter Your Choice");
                    Console.WriteLine("[1] Add, Modify or Delete Personal Details");
                    Console.WriteLine("[2] Add, Modify or Delete Skills");
                    Console.WriteLine("[3] Add, Modify or Delete Education Details");
                    Console.WriteLine("[4] Add, Modify or Delete Company Details/Experience");
                    Console.WriteLine("[5] Add, Modify or Delete Achivements");
                    Console.WriteLine("[7] Get all triners skills using fluent api");
                    Console.WriteLine("[8] Get all triners using fluent api");
                    Console.WriteLine("[6] View Your Profile");
                    Console.WriteLine("[0] Exit");
                    Console.WriteLine("Enter Your choice");
                    int ch = Convert.ToInt32(Console.ReadLine());

                    switch (ch)
                    {
                        case 0:
                            Console.WriteLine();
                            repeat = false;
                            break;
                        case 1:
                            trainerMenu(t);
                            if (accountDeleted == true)
                            {
                                repeat = false;
                            }
                            break;
                        case 2:
                            skillMenu(tid);
                            break;
                        case 3:
                            educationMenu(tid);
                            break;
                        case 4:
                            exprienceMenu(tid);
                            break;
                        case 5:
                            achivementsMenu(tid);
                            break;
                        case 6:
                            View(t);
                            Log.Information("Viewing Profile");
                            break;
                        case 7:
                            //var skills = bl.GetSkil(tid);
                            //foreach (var value in skills)
                            //{
                            //    Console.WriteLine(value.ToString());
                            //}
                            //Console.ReadKey();
                            break;
                        case 8:
                            var values = bl.GetTrainers();
                            foreach(var value in values)
                            {
                                Console.WriteLine(value.ToString());
                            }
                            Console.ReadKey();
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please Check Your Internet Connection");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message+"Please Try Again"); 
                Console.ReadKey();
                LoginMenu();
            }
        }

        public void trainerMenu(Trainer t)
        {
            bool repeat = true;
            while (repeat)
            {
               Console.Clear();
                ISqlRepo r = new trainerTable(File.ReadAllText("../../../ConnectionString.txt"));

                Console.WriteLine("Enter Your Choice to Modify Your Personel details");
                Console.WriteLine("[1] Add Personal Details if you are logging in for the first time");
                Console.WriteLine("[2] Display Personal Details");
                Console.WriteLine("[3] Update Personal Details");
                Console.WriteLine("[4] Delete Your Account");
                Console.WriteLine("[0] Go back to Menu");

                Console.WriteLine("Enter Your choice");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {

                    case 1:
                        Log.Information("Adding User Personal Details");
                        r.addData(t);
                        Console.ReadKey();
                        break;
                    case 2:
                        Log.Information("Viewing User Personal Details ");
                        Console.WriteLine(r.getData(t).ToString());
                        Console.WriteLine("Click any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                        r.updateData(t);
                        Console.ReadKey();
                        break;
                    case 4:
                        if (r.deleteData(t))
                        {
                            repeat= false;
                            accountDeleted = true;
                            Console.ReadKey();
                            Log.Information("User Account Deleted");

                        };
                        break;
                    case 0:
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please enter correct option");
                        Console.ReadKey();
                        break;
                }
            }

        }

        public void skillMenu( int tid)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                //Skill s=new Skill();
                IchildSql i = new skillTable(File.ReadAllText("../../../ConnectionString.txt"));

                Console.WriteLine("Enter Your Choice to Modify Your Skills");
                Console.WriteLine("[1] Add Skills");
                Console.WriteLine("[2] Display Skills");
                Console.WriteLine("[3] Update Skills");
                Console.WriteLine("[4] Delete skills");
                Console.WriteLine("[0] Go back to Menu");

                Console.WriteLine("Enter Your choice");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {

                    case 1:
                        i.add(tid);
                        Log.Information("Inserting Skills");
                        Console.ReadKey();
                        break;
                    case 2:
                        i.view(tid);
                        Log.Information("Viewing Skills");
                        Console.WriteLine("Click any key to continue");
                        Console.ReadKey();
                        break;
                    case 3:
                        i.update(tid);
                        Console.ReadKey();
                        Log.Information("Updating Skills");
                        break;
                    case 4:
                        i.delete(tid);
                        Console.ReadKey();
                        Log.Information("Deleting Skills");
                        break;
                    case 0:
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter Correct Option");
                        break;
                }
            }

        }


        public void educationMenu(int tid)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                
                IchildSql i = new educationTable(File.ReadAllText("../../../ConnectionString.txt"));

                Console.WriteLine("Enter Your Choice to Modify Your Education Details");
                Console.WriteLine("[1] Add Education Details");
                Console.WriteLine("[2] Display Education Details");
                Console.WriteLine("[3] Update Education Details");
                Console.WriteLine("[4] Delete Education Details");
                Console.WriteLine("[0] Go back to Menu");

                Console.WriteLine("Enter Your choice");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {

                    case 1:
                        i.add(tid);
                        Console.ReadKey();
                        Log.Information("Adding Education Details");
                        break;
                    case 2:
                        i.view(tid);
                        Console.WriteLine("Click any key to continue");
                        Console.ReadKey();
                        Log.Information("Viewing Education Details");
                        break;
                    case 3:
                        i.update(tid);
                        Console.ReadKey();
                        Log.Information("Updating Education Details");
                        break;
                    case 4:
                        i.delete(tid);
                        Console.ReadKey();
                        Log.Information("Deleting Education Details");
                        break;
                    case 0:
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Plese Enter correct option");
                        Console.ReadKey();
                        break;
                }
            }

        }


        public void exprienceMenu(int tid)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                IchildSql i = new experienceTable(File.ReadAllText("../../../ConnectionString.txt"));

                Console.WriteLine("Enter Your Choice to Modify Your Experience Details");
                Console.WriteLine("[1] Add Experience Details");
                Console.WriteLine("[2] Display Experience Details");
                Console.WriteLine("[3] Update Experience Details");
                Console.WriteLine("[4] Delete Experience Details");
                Console.WriteLine("[0] Go back to Menu");

                Console.WriteLine("Enter Your choice");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {

                    case 1:
                        i.add(tid);
                        Console.ReadKey();
                        Log.Information("Adding Experience");
                        break;
                    case 2:
                        i.view(tid);
                        Console.WriteLine("Click any key to continue");
                        Console.ReadKey();
                        Log.Information("Viewing Experience");
                        break;
                    case 3:
                        i.update(tid);
                        Console.ReadKey();
                        Log.Information("Updating Experience");
                        break;
                    case 4:
                        i.delete(tid);
                        Console.ReadKey();
                        Log.Information("Deleting Experience");
                        break;
                    case 0:
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter correct choice");
                        Console.ReadKey();
                        break;
                }
            }

        }

        public void achivementsMenu(int tid) 
        {
            bool repeat = true;
            while (repeat)
            {
                Console.Clear();
                IchildSql i = new achivementsTable(File.ReadAllText("../../../ConnectionString.txt"));

                Console.WriteLine("Enter Your Choice to Modify Your Achivements/Certifications");
                Console.WriteLine("[1] Add Achivements/Certifications");
                Console.WriteLine("[2] Display Achivements/Certifications");
                Console.WriteLine("[3] Update Achivements/Certifications");
                Console.WriteLine("[4] Delete Achivements/Certifications");
                Console.WriteLine("[0] Go back to Menu");

                Console.WriteLine("Enter Your choice");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {

                    case 1:
                        i.add(tid);
                        Console.ReadKey();
                        Log.Information("Adding Achivements/Certifications");
                        break;
                    case 2:
                        i.view(tid);
                        Console.WriteLine("Click any key to continue");
                        Console.ReadKey();
                        Log.Information("Viewing Achivements/Certifications");
                        break;
                    case 3:
                        i.update(tid);
                        Console.ReadKey();
                        Log.Information("Updating Achivements/Certifications");
                        break;
                    case 4:
                        i.delete(tid);
                        Console.ReadKey();
                        Log.Information("Deleting Achivements/Certifications");
                        break;
                    case 0:
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter Correct option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void View(Trainer t )
        {
            Console.Clear();
            Console.WriteLine("Your Profile:\n");
            ISqlRepo r = new trainerTable(File.ReadAllText("../../../ConnectionString.txt"));
            Console.WriteLine(r.getData(t));
            IchildSql i = new skillTable(File.ReadAllText("../../../ConnectionString.txt"));
            i.view(tid);
            i = new experienceTable(File.ReadAllText("../../../ConnectionString.txt"));
            i.view(tid);
            i = new educationTable(File.ReadAllText("../../../ConnectionString.txt"));
            i.view(tid);
            i = new achivementsTable(File.ReadAllText("../../../ConnectionString.txt"));
            i.view(tid);

           Console.WriteLine("Click any key to continue");
            Console.ReadKey();
        }
    }
}
