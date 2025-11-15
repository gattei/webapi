using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Registi
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public DateOnly Nascita { get; set; }

    public DateOnly? Morte { get; set; }

    public string? Nazionalita { get; set; }

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
