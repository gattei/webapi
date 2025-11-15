using System;
using System.Collections.Generic;

namespace webapi.Models;

public partial class Film
{
    public int Id { get; set; }

    public string? Titolo { get; set; }

    public int IdRegista { get; set; }

    public int Anno { get; set; }

    public virtual Registi IdRegistaNavigation { get; set; } = null!;
}
