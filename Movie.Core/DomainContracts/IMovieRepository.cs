using Movie.Core.Entities;

namespace Movie.Core.DomainContracts;

public interface IMovieRepository 
{
    Task<List<MovieFilm>> GetMovieAsync();
    Task<MovieFilm> GetMovieAsync(int id);
    Task PutMovieAsync(int id, MovieFilm movie);
    Task PostMovieAsync(MovieFilm movie);
    Task DeleteMovie(int id);
}
