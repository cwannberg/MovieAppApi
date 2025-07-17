using Movie.Data.Repositories;

namespace Movie.Data;

internal class UnitOfWork
{
    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Movies = new MovieRepository(_context);
        Reviews = new ReviewRepository(_context);
        Actors = new ActorRepository(_context);
        Genres = new GenreRepository(_context);
    }

    public MovieRepository Movies { get; }
    public ReviewRepository Reviews { get; }
    public ActorRepository Actors { get; }
    public GenreRepository Genres { get; }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}