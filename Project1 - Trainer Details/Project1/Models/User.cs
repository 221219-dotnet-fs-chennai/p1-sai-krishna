using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        string email;
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
                    email = "false";
            }
        }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool Login { get; set; }
    }
}
