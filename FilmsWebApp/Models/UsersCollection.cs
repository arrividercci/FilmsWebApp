using System;
using System.Collections.Generic;

namespace FilmsWebApp;

public partial class UsersCollection
{
    public int Id { get; set; }

    public int FilmStatusRateId { get; set; }

    public int UserId { get; set; }

    public virtual FilmStatusRate FilmStatusRate { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
