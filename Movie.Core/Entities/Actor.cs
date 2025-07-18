﻿namespace Movie.Core.Entities;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int BirthYear { get; set; }
    public ICollection<MovieFilm> Movies { get; set; } = new List<MovieFilm>();
}
