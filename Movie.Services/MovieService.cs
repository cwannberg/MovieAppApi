using AutoMapper;
using Movie.Core.Dtos;
using Movie.Core.Entities;
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
        public async Task<IEnumerable<MovieDto>> GetAllAsync() => mapper.Map<IEnumerable<MovieDto>>(await uow.MovieRepository.GetAllAsync());
        public async Task<MovieDto> GetAsync(int id) => mapper.Map<MovieDto>(await uow.MovieRepository.GetAsync(id));
        public async Task PutAsync(int id, MovieDto movieDto) => await uow.MovieRepository.PutAsync(id, mapper.Map<MovieFilm>(movieDto));
        public async Task<MovieDto> PostAsync(MovieCreateDto movieDto)
        {
            var movie = mapper.Map<MovieFilm>(movieDto);

            // Validera: om GenreId är satt, kontrollera att den finns
            if (movieDto.GenreId.HasValue)
            {
                var genreExists = await uow.GenreRepository.ExistsAsync(movieDto.GenreId.Value);
            }

            await uow.MovieRepository.PostAsync(movie);
            await uow.CompleteAsync();

            return mapper.Map<MovieDto>(movie);
            //var movie = mapper.Map<MovieFilm>(movieDto);
            //await uow.MovieRepository.PostAsync(movie);
            //return mapper.Map<MovieDto>(movie);
        }
        public async Task DeleteAsync(int id) => await uow.MovieRepository.DeleteAsync(id);
    }
}