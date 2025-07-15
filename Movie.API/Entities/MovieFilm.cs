﻿namespace Movie.API.Entities;

public class MovieFilm
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Year { get; set; }
    public string? Duration { get; set; }

    //1-1
    public int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;

    //1-1
    public MovieDetails MovieDetails { get; set; } = null!;

    //1-M
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    //N-M
    public ICollection<Actor> Actors { get; set; } = new List<Actor>();
}
