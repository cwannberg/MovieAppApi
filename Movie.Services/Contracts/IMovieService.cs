using Movie.Core.Dtos;

namespace Movie.Services.Contracts
{
    public interface IMovieService : IBaseService<MovieDto>
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<MovieDto> GetAsync(int id);
        Task PutAsync(int id, MovieDto item);
        Task<MovieDto> PostAsync(MovieCreateDto item);
        Task DeleteAsync(int id);
    }
}