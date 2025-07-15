using System.ComponentModel.DataAnnotations;

namespace Movie.Core.Dtos;

public record ActorCreateDto(int Id, [Required] string Name, int BirthYear);
