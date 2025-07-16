using Movie.Core.DomainContracts;
using Movie.Core.Entities;

namespace Movie.Data.Repositories;

public class ActorRepository : IActorRepository
{
    private ApplicationDbContext _context { get; }

    public ActorRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task DeleteActor(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Actor>> GetActorAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Actor> GetActorAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task PostActorAsync(Actor actor)
    {
        throw new NotImplementedException();
    }

    public Task PutActorAsync(int id, Actor actor)
    {
        throw new NotImplementedException();
    }
}
