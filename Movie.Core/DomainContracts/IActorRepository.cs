using Movie.Core.Entities;

namespace Movie.Core.DomainContracts;

public interface IActorRepository
{
    Task<IEnumerable<Actor>> GetActorAsync();
    Task<Actor> GetActorAsync(int id);
    Task PutActorAsync(int id, Actor actor);
    Task PostActorAsync(Actor actor);
    Task DeleteActor(int id);
}
