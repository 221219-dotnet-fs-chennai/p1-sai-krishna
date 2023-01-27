using System;
using System.Collections.Generic;

namespace Data__FluentApi.Entities;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public string Name { get; set; } = null!;

    public string? Gender { get; set; }

    public string PhoneNo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Pincode { get; set; }

    public string? AboutMe { get; set; }

    public override string ToString()
    {
        return ($" Name: {Name}\n Gender: {Gender}\n Email: {Email}\t\t\tPhone No: {PhoneNo}\n Address: {City}, {State}, {Pincode}\n About Me: {AboutMe}\n");
    }

    public virtual ICollection<Achivement> Achivements { get; } = new List<Achivement>();

    public virtual ICollection<Education> Educations { get; } = new List<Education>();

    public virtual ICollection<Experience> Experiences { get; } = new List<Experience>();

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}
