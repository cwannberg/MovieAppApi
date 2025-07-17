using Movie.Core.Dtos;
using Movie.Core.Entities;

namespace Movie.Services.Contracts
{
    public interface IGenreService : IBaseService<GenreDto>
    {
        Task<GenreDto> PostAsync(GenreDto genreDto);
    }
}