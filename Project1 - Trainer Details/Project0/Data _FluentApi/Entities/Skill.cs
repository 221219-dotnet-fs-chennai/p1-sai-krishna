using System;
using System.Collections.Generic;

namespace Data__FluentApi.Entities;

public partial class Skill
{
    public int? TrainerId { get; set; }

    public string? SkillName { get; set; }

    public string? Description { get; set; }

    public int SkillId { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
