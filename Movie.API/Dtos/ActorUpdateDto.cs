using System.ComponentModel.DataAnnotations;

namespace Movie.API.Dtos
{
    public class ActorUpdateDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public int BirthYear { get; set; }
    }
}
