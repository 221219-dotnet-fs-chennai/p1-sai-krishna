using System.Numerics;
using System.Text.RegularExpressions;

namespace Models
{
    public class Trainer
    {
       
        
        
        public int Id { get; set;}
        public string Name { get; set;}
        public string? Gender
        {
            get;set;
        }
        public string PhoneNo {
            get;set;
        }
        public string Email
        { get;set;
        }
        public string Password { get; set;}
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Pincode { get; set; }
        public string? AboutMe { get; set; }

 

        public override string ToString()
        {
            return($" {Id}-Name: {Name}\n Gender: {Gender}\n Email: {Email}\t\t\tPhone No: {PhoneNo}\n Address: {City}, {State}, {Pincode}\n About Me: {AboutMe}\n"); 
        }




    }
}