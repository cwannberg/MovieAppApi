using Microsoft.EntityFrameworkCore;
using Movie.Core.DomainContracts;
using Movie.Core.Entities;

namespace Movie.Data.Repositories;

public class MovieRepository : IMovieRepository
{
    private ApplicationDbContext _context { get; }

    public MovieRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<MovieFilm>> GetAllAsync(int pageNumber, int pageSize)
    {
        return await _context.Movies
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
    }

    public async Task<MovieFilm> GetAsync(int id) => await _context.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();

    public async Task PutAsync(int id, MovieFilm movie)
    {
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
    }

    public async Task PostAsync(MovieFilm movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
    }

    public async Task<int> GetTotalCountAsync()
    {
        return await _context.Movies.CountAsync();
    }
}
