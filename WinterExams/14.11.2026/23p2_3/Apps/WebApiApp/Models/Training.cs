using System;
using System.Collections.Generic;

namespace WebApiApp.Models;

public partial class Training
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public int Trainer { get; set; }

    public bool IsVisited { get; set; }

    public int Hall { get; set; }

    public virtual User TrainerNavigation { get; set; } = null!;

    public virtual ICollection<TrainingList> TrainingLists { get; set; } = new List<TrainingList>();
}
