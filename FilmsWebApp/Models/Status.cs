using System;
using System.Collections.Generic;

namespace FilmsWebApp;

public partial class Status
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<FilmStatusRate> FilmStatusRates { get; } = new List<FilmStatusRate>();
}
