using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Data
{
    public class Experience 
    {
        string sdate,edate;
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public string StartDate
        {
            get
            {
                return sdate;
            }
            set
            {
                string pattern = @"^((0[1-9])|(1[0-2]))/2\d{3}$";
                var IsEmailCorrect = Regex.IsMatch(value, pattern);
                if (IsEmailCorrect)
                    sdate = value;
                else
                    sdate = "false";
            }
        }
        public string EndDate
        {
            get
            {
                return edate;
            }
            set
            {
                string pattern = @"^(((0[1-9])|(1[0-2]))/2\d{3})$|^Present$";
                var IsEmailCorrect = Regex.IsMatch(value, pattern);
                if (IsEmailCorrect)
                    edate = value;
                else
                    edate = "false";
            }
        }
       
    }
}
