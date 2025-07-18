using Movie.Core.Dtos;
using Movie.Core;

namespace Movie.Services.Contracts
{
    public interface IMovieService : IBaseService<MovieDto>
    {
        Task<IEnumerable<MovieDto>> GetAllAsync(int pageNumber, int pageSize);
        Task<MovieDto> GetAsync(int id);
        Task PutAsync(int id, MovieDto item);
        Task<MovieDto> PostAsync(MovieCreateDto item);
        Task DeleteAsync(int id);
        Task<PagedResult<MovieDto>> GetPagedAsync(int pageNumber, int pageSize);
    }
}