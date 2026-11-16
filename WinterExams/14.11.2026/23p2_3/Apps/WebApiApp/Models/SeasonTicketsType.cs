using System;
using System.Collections.Generic;

namespace WebApiApp.Models;

public partial class SeasonTicketsType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<SeasonTicket> SeasonTickets { get; set; } = new List<SeasonTicket>();
}
