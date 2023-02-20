using System;
using System.Collections.Generic;

namespace FilmsWebApp;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<UsersCollection> UsersCollections { get; } = new List<UsersCollection>();
}
