using System;
using System.Collections.Generic;

namespace Data__FluentApi.Entities;

public partial class Experience
{
    public int? TrainerId { get; set; }

    public string? CmpName { get; set; }

    public string? Role { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public int ExperiencId { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
