using System.ComponentModel.DataAnnotations;

namespace Movie.Core.Dtos;

public class ActorDto
{
    [Required]
    public string Name { get; set; } = null!;
    public int BirthYear { get; set; }

    public ICollection<ActorsMoviesDto> Movies { get; set; } = new List<ActorsMoviesDto>();
}
