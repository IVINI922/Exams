using System;
using System.Collections.Generic;

namespace WebApiApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string? Phone { get; set; }

    public int Role { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Role RoleNavigation { get; set; } = null!;

    public virtual ICollection<Training> Training { get; set; } = new List<Training>();
}
