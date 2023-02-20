using System;
using System.Collections.Generic;

namespace FilmsWebApp;

public partial class Film
{
    public int Id { get; set; }

    public int GenreId { get; set; }

    public int AuthorId { get; set; }

    public int CountryId { get; set; }

    public int Year { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? PicturePath { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<FilmStatusRate> FilmStatusRates { get; } = new List<FilmStatusRate>();

    public virtual Genre Genre { get; set; } = null!;
}
