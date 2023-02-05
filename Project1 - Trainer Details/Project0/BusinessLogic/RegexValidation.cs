using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class RegexValidation
    {
        public static bool isValidEmail(string email)
        {
            string pattern = @"^\w+@\w+\.\w{2,4}$";
            if (Regex.IsMatch(email, pattern))
            {
                return true;
            }
            else
            { return false; }

        }

        public static bool isValidPassword(string password)
        {
            string pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,20}$";
            if (Regex.IsMatch(password, pattern))
            {
                return true;
            }
            else
            { return false; }

        }
        public static bool isValidPhone(string phone)
        {
            string pattern = @"^[6-9]\d{9}$";
            if (Regex.IsMatch(phone, pattern))
            {
                return true;
            }
            else
            { return false; }

        }

        public static bool isValidGender(string gender)
        {
            string pattern = @"^(M|F)$";
            if (Regex.IsMatch(gender, pattern) || gender == null)
            {
                return true;
            }
            else
            { return false; }

        }

        public static bool isValidZipcode(string zipcode)
        {
            string pattern = @"^[1-9]\d{5}$";
            if (Regex.IsMatch(zipcode, pattern) || zipcode == null)
            {
                return true;
            }
            else
            { return false; }

        }

        public static bool isValidStartDate(string sdate)
        {
            string pattern = @"^((0[1-9])|(1[0-2]))/2\d{3}$";
            if (Regex.IsMatch(sdate, pattern) || sdate == null)
            {
                return true;
            }
            else
            { return false; }

        }

        public static bool isValidEndDate(string edate)
        {
            string pattern = @"^(((0[1-9])|(1[0-2]))/2\d{3})$|^Present$";
            if (Regex.IsMatch(edate, pattern) || edate == null)
            {
                return true;
            }
            else
            { return false; }

        }
    }
}
