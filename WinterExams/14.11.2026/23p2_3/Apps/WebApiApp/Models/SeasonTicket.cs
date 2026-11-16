using System;
using System.Collections.Generic;

namespace WebApiApp.Models;

public partial class SeasonTicket
{
    public int Id { get; set; }

    public int Type { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual SeasonTicketsType TypeNavigation { get; set; } = null!;
}
