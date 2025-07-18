using Movie.Core.Dtos;

namespace Movie.Services.Contracts
{
    public interface IBaseService<TDto>
    {
        Task<IEnumerable<TDto>> GetAllAsync(int pageSize, int pageNumber);
        Task<TDto> GetAsync(int id);
        Task PutAsync(int id, TDto item);
        Task DeleteAsync(int id);
    }
}