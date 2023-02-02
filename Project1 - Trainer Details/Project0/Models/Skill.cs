using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Skill
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"-> {Name}{new string(' ',25-(Name.Length))}-{Description}\n";
        }
    }
}
