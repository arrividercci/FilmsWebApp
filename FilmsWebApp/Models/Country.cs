using System;
using System.Collections.Generic;

namespace FilmsWebApp;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Film> Films { get; } = new List<Film>();
}
