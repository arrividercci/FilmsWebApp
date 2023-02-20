using System;
using System.Collections.Generic;

namespace FilmsWebApp;

public partial class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Film> Films { get; } = new List<Film>();
}
