using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Actor>> GetAllAsync(int pageNumber, int pageSize)
    {
        return await _context.Actors
                    .Include(a => a.Movies)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
    }

    public async Task<Actor> GetAsync(int id) => await _context.Actors.Where(a => a.Id == id).FirstOrDefaultAsync();

    public async Task PutAsync(int id, Actor actor)
    {
        _context.Actors.Update(actor);
        await _context.SaveChangesAsync();
    }

    public async Task PostAsync(Actor actor)
    {
        _context.Actors.Add(actor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var actor = await _context.Actors.FindAsync(id);
        _context.Actors.Remove(actor);
        await _context.SaveChangesAsync();
    }
    public async Task<int> GetTotalCountAsync()
    {
        return await _context.Actors.CountAsync();
    }
}
