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
    public async Task<List<MovieFilm>> GetMovieAsync()
    {
        return await _context.Movies.ToListAsync();
    }
    public async Task<MovieFilm> GetMovieAsync(int id)
    {
         return await _context.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
    }
    public async Task PutMovieAsync(int id, MovieFilm movie)
    {
        _context.Entry(movie).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public async Task PostMovieAsync(MovieFilm movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteMovie(int id)
    {
        if (MovieExists(id))
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
    private bool MovieExists(int id)
    {
        return _context.Movies.Any(e => e.Id == id);
    }
}
