using AutoMapper;
using Movie.Core.Dtos;
using Movie.Services.Contracts;

namespace Movie.Services
{
    public class MovieService : IMovieService
    {
        private IUnitOfWork uow;
        private readonly IMapper mapper;

        public MovieService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> GetMoviesAsync()
        {
            return mapper.Map<IEnumerable<MovieDto>>(await uow.MovieRepository.GetMovieAsync());
        }
    }
}