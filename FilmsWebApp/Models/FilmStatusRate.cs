using System;
using System.Collections.Generic;

namespace FilmsWebApp;

public partial class FilmStatusRate
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int StatusId { get; set; }

    public int? Rate { get; set; }

    public virtual Film Book { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<UsersCollection> UsersCollections { get; } = new List<UsersCollection>();
}
