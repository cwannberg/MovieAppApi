using System.ComponentModel.DataAnnotations;

namespace Movie.API.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; } = null!;
        public int Rating { get; set; }
        public int MovieId { get; set; }
        public MovieFilm Movie { get; set; } = null!;
    }
}
