using Movie.Core.Entities;

namespace Movie.Core.DomainContracts;

public interface IMovieRepository : IBaseRepository<MovieFilm>
{
    Task<List<MovieFilm>> GetAllAsync(int pageSize, int pageNumber);
    Task<MovieFilm> GetAsync(int id);
    Task PutAsync(int id, MovieFilm item);
    Task PostAsync(MovieFilm item);
    Task DeleteAsync(int id);
    Task<int> GetTotalCountAsync();
}
