using System.ComponentModel.DataAnnotations;

namespace Movie.Core.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public int Year { get; set; }
    public string Duration { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public MovieDetailDto MovieDetail { get; set; }
    public ICollection<ActorDto> Actors { get; set; }
}
