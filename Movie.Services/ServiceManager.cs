using AutoMapper;
using Movie.Services.Contracts;

namespace Movie.Services;

public class ServiceManager : IServiceManager
{
    private Lazy<IActorService> _actorService;
    private Lazy<IMovieService> _movieService;
    private Lazy<IReviewService> _reviewService;
    private Lazy<IGenreService> _genreService;

    public IMovieService MovieService => _movieService.Value;
    public IActorService ActorService => _actorService.Value;
    public IReviewService ReviewService => _reviewService.Value;
    public IGenreService GenreService => _genreService.Value;
    public ServiceManager(IUnitOfWork uow, IMapper mapper)
    {
        _movieService = new Lazy<IMovieService>(() => new MovieService(uow, mapper));
        _reviewService = new Lazy<IReviewService>(() => new ReviewService(uow));
        _actorService = new Lazy<IActorService>(() => new ActorService(uow, mapper));
        _genreService = new Lazy<IGenreService>(() => new GenreService(uow, mapper));
    }
}
