using System;
using System.Collections.Generic;

namespace WebApiApp.Models;

public partial class Client
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateOnly BirthDate { get; set; }

    public int SeasonTicket { get; set; }

    public virtual SeasonTicket SeasonTicketNavigation { get; set; } = null!;

    public virtual ICollection<TrainingList> TrainingLists { get; set; } = new List<TrainingList>();

    public virtual User User { get; set; } = null!;
}
