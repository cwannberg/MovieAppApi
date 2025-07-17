using Microsoft.EntityFrameworkCore;
using Movie.Core.DomainContracts;
using Movie.Core.Entities;

namespace Movie.Data.Repositories;

public class GenreRepository : IGenreRepository
{
    private ApplicationDbContext _context { get; }

    public GenreRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Genre>> GetAllAsync() => await _context.Genres.ToListAsync();

    public async Task<Genre> GetAsync(int id) => await _context.Genres.Where(m => m.Id == id).FirstOrDefaultAsync();

    public async Task PutAsync(int id, Genre genre)
    {
        _context.Genres.Update(genre);
        await _context.SaveChangesAsync();
    }

    public async Task PostAsync(Genre genre)
    {
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> ExistsAsync(int genreId)
    {
        return await _context.Genres.AnyAsync(g => g.Id == genreId);
    }
}
