using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<MovieDto>>(await uow.MovieRepository.GetAllAsync());
        }
        public async Task<MovieDto> GetAsync(int id)
        {
            var movie = await uow.MovieRepository.GetAsync(id);
            return mapper.Map<MovieDto>(movie);
        }

        public Task PutAsync(int id, MovieDto item)
        {
            throw new NotImplementedException();
        }

        public Task PostAsync(MovieDto item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}