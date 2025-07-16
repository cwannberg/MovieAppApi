using Movie.Core.DomainContracts;

namespace Movie.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly Lazy<IMovieRepository> movieRepository;
    private readonly Lazy<IReviewRepository> reviewRepository;
    private readonly Lazy<IActorRepository> actorRepository;
    public IMovieRepository MovieRepository => movieRepository.Value;
    public IReviewRepository ReviewRepository => reviewRepository.Value;
    public IActorRepository ActorRepository => actorRepository.Value;
    private ApplicationDbContext _context { get; }
    public UnitOfWork(ApplicationDbContext context)
    {
        movieRepository = new Lazy<IMovieRepository>(() => new MovieRepository(context));
        reviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(context));
        actorRepository = new Lazy<IActorRepository>(() => new ActorRepository(context));
        _context = context;
    }
    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}
