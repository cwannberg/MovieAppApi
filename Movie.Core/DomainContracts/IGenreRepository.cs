using Movie.Core.Entities;

namespace Movie.Core.DomainContracts
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<List<Genre>> GetAllAsync();
        Task PostAsync(Genre item);
    }
}