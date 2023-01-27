using System;
using System.Collections.Generic;

namespace Data__FluentApi.Entities;

public partial class Education
{
    public int? TrainerId { get; set; }

    public string? InstituteName { get; set; }

    public string? Degree { get; set; }

    public string? StartDate { get; set; }

    public string? EndDate { get; set; }

    public string? Cgpa { get; set; }

    public int EducationId { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
