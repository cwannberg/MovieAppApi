using Movie.Core.Entities;

namespace Movie.Core.DomainContracts;

public interface IActorRepository : IBaseRepository<Actor>
{
    Task<List<Actor>> GetAllAsync(int pageSize, int pageNumber);
    Task<Actor> GetAsync(int id);
    Task PutAsync(int id, Actor actor);
    Task PostAsync(Actor actor);
    Task DeleteAsync(int id);
    Task<int> GetTotalCountAsync();
}
