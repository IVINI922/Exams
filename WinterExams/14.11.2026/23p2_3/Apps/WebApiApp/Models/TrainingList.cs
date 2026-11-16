using System;
using System.Collections.Generic;

namespace WebApiApp.Models;

public partial class TrainingList
{
    public int Id { get; set; }

    public int Client { get; set; }

    public int Training { get; set; }

    public virtual Client ClientNavigation { get; set; } = null!;

    public virtual Training TrainingNavigation { get; set; } = null!;
}
