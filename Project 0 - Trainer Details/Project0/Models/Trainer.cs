using System.Numerics;
using System.Text.RegularExpressions;

namespace Data
{
    public class Trainer
    {
        public string pincode;
        public string phone,email;
        string? gender;
        //city,state,zipcode,aboutme;
        public int Id { get; set;}
        public string Name { get; set;}
        public string Gender
        {
            get
            {
                return gender;
            }
            set 
            {
                if (Regex.IsMatch(value, "^(M|F)$"))
                {
                    gender = value;
                }
                else
                {
                    gender = "false";
                }
                
            }
        }
        public string PhoneNo {
            get { 
                return phone; 
            }
            set
            {               
                    phone = value;                
            }
        }
        public string Email
        {
            get
            {
                return email; ;
            }
            set
            {
                string pattern = @"^\w+@\w+\.\w{2,4}$";
                var IsEmailCorrect = Regex.IsMatch(value, pattern);
                if (IsEmailCorrect)
                    email = value;
                else
                    email="false";
            }
        }
        public string Password { get; set;}
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode {
            get
            {
                return pincode;
            }
            set
            {
                string pattern = @"^[1-9]\d{5}$";
                var IsPincodeCorrect = Regex.IsMatch(value, pattern);
                if (IsPincodeCorrect)
                    pincode = value;
                else
                    //Console.WriteLine("Please add a valid Pincode with 6 digits only");
                    pincode= "false";
            }
        }
        public string AboutMe { get; set; }

        public bool Login { get; set; }

        public bool SignUp { get; set; }

        public override string ToString()
        {
            return($" Name: {Name}\n Gender: {Gender}\n Email: {Email}\t\t\tPhone No: {PhoneNo}\n Address: {City}, {State}, {Pincode}\n About Me: {AboutMe}\n"); 
        }




    }
}