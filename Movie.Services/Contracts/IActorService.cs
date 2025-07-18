using Movie.Core.Dtos;
using Movie.Core;

namespace Movie.Services.Contracts
{
    public interface IActorService : IBaseService<ActorDto>
    {
        Task<IEnumerable<ActorDto>> GetAllAsync(int pageNumber, int pageSize);
        Task<ActorDto> GetAsync(int id);
        Task PutAsync(int id, ActorDto item);
        Task<ActorDto> PostAsync(ActorCreateDto item);
        Task DeleteAsync(int id);
        Task<PagedResult<ActorDto>> GetPagedAsync(int pageNumber, int pageSize);
    }
}