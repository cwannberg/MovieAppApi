using System.ComponentModel.DataAnnotations;

namespace Movie.API.Dtos;

public record ActorCreateDto(int Id, [Required] string Name, int BirthYear);
