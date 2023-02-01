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

  

    public virtual ICollection<Achivement> Achivements { get; } = new List<Achivement>();

    public virtual ICollection<Education> Educations { get; } = new List<Education>();

    public virtual ICollection<Experience> Experiences { get; } = new List<Experience>();

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}
