using System.ComponentModel.DataAnnotations;

namespace Movie.Core.Dtos
{
    public record GenreDto {
        public int Id {get; set; }
        [Required]
        public string Name { get; set; } = null!;
    };
}
