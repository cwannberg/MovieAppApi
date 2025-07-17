using Movie.Core.Entities;

namespace Movie.Core.DomainContracts;

public interface IMovieRepository : IBaseRepository<MovieFilm>
{
    Task<List<MovieFilm>> GetAllAsync();
    Task<MovieFilm> GetAsync(int id);
    Task PutAsync(int id, MovieFilm item);
    Task PostAsync(MovieFilm item);
    Task DeleteAsync(int id);
}
