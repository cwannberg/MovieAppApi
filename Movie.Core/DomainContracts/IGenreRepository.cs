using Movie.Core.Entities;

namespace Movie.Core.DomainContracts
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<List<Genre>> GetAllAsync(int pageNumber, int pageSize);
        Task PostAsync(Genre item);
        Task<bool> ExistsAsync(int genreId);
        Task<int> GetTotalCountAsync();
    }
}