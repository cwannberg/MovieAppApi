using Movie.Core.Dtos;
using Movie.Services.Contracts;

namespace Movie.Services
{
    public class MovieService : IMovieService
    {
        private IUnitOfWork uow;

        public MovieService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Task<IEnumerable<MovieDto>> GetMoviesAsync()
        {
            throw new NotImplementedException();
        }
    }
}