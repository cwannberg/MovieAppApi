using AutoMapper;
using Movie.Core.Dtos;
using Movie.Core.Entities;
using Movie.Services.Contracts;

namespace Movie.Services
{
    public class GenreService : IGenreService
    {
        private IUnitOfWork uow;
        private readonly IMapper mapper;

        public GenreService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<GenreDto>> GetAllAsync() => mapper.Map<IEnumerable<GenreDto>>(await uow.GenreRepository.GetAllAsync());
       
        public async Task<GenreDto> PostAsync(GenreDto genreDto)
        {
            var genre = mapper.Map<Genre>(genreDto);
            await uow.GenreRepository.PostAsync(genre);
            return mapper.Map<GenreDto>(genre);
        }

        public Task<GenreDto> GetAsync(int id)
        {
            return Task.FromResult<GenreDto>(null);
        }

        public Task PutAsync(int id, GenreDto item)
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            return Task.CompletedTask;
        }
    }
}