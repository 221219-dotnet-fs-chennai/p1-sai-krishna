using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Models
{
    public class Education
    {
        string sdate, edate;
        public int? Id{get;set;}
        public string? InstituteName { get; set; }
        public string? Degree { get; set; }
        public string? StartDate
        {
            get; set;
        }
        public string? EndDate
        {
            get; set;
        }
        public string? Score { get; set; }


    }
}
