using System.ComponentModel.DataAnnotations;

namespace Movie.Core.Dtos;

public class ActorDto
{
    public int Id { get; set; } 
    [Required]
    public string Name { get; set; } = null!;
    public int BirthYear { get; set; }

    public ICollection<ActorsMoviesDto> Movies { get; set; } = new List<ActorsMoviesDto>();
}
