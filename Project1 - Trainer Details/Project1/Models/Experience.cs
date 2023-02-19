using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models
{
    public class Experience 
    {
        
        public int? Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Role { get; set; }
        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

    }
}
