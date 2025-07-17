using Movie.Core.DomainContracts;

namespace Movie.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly Lazy<IMovieRepository> movieRepository;
    private readonly Lazy<IReviewRepository> reviewRepository;
    private readonly Lazy<IActorRepository> actorRepository;
    private readonly Lazy<IGenreRepository> genreRepository;
    public IMovieRepository MovieRepository => movieRepository.Value;
    public IReviewRepository ReviewRepository => reviewRepository.Value;
    public IActorRepository ActorRepository => actorRepository.Value;
    public IGenreRepository GenreRepository => genreRepository.Value;
    private ApplicationDbContext _context { get; }
    public UnitOfWork(ApplicationDbContext context)
    {
        movieRepository = new Lazy<IMovieRepository>(() => new MovieRepository(context));
        reviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(context));
        actorRepository = new Lazy<IActorRepository>(() => new ActorRepository(context));
        genreRepository = new Lazy<IGenreRepository>(() => new GenreRepository(context));
        _context = context;
    }
    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}
