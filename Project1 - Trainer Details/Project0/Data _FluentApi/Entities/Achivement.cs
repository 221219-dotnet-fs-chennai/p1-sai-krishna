using System;
using System.Collections.Generic;

namespace Data__FluentApi.Entities;

public partial class Achivement
{
    public int? TrainerId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int AchivementsId { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
