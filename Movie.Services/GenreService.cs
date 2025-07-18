using AutoMapper;
using Movie.Core.Dtos;
using Movie.Core;
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
        public async Task<IEnumerable<GenreDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            var genres = await uow.GenreRepository.GetAllAsync(pageNumber, pageSize);
            return mapper.Map<IEnumerable<GenreDto>>(genres);
        }
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
        public async Task<PagedResult<GenreDto>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var totalItems = await uow.GenreRepository.GetTotalCountAsync();
            var genres = await uow.GenreRepository.GetAllAsync(pageNumber, pageSize);
            var genresDto = mapper.Map <IEnumerable<GenreDto>>(genres);
            return new PagedResult<GenreDto>
            {
                Data = genresDto,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };
        }
    }
}