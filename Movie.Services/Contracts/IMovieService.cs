using Movie.Core.Dtos;

namespace Movie.Services.Contracts
{
    public interface IMovieService
    {

        Task<IEnumerable<MovieDto>> GetMoviesAsync();
    }
}