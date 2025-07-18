using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dtos;
using Movie.Core;
using Movie.Core.Entities;
using Movie.Services.Contracts;
using System.Threading.Tasks;
using System.Text.Json;

namespace Movie.Presentation.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        const int maxPageSize = 100;

        public GenreController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<PagedResult<IEnumerable<GenreDto>>>> GetGenre(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxPageSize)
                pageSize = maxPageSize;
            var result = await serviceManager.MovieService.GetPagedAsync(pageNumber, pageSize);

            var metaData = new
            {
                result.TotalItems,
                result.CurrentPage,
                result.PageSize,
                result.TotalPages,
            };
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GenreDto>> PostGenre([FromBody] GenreDto genreDto)
        {
            var genre = await serviceManager.GenreService.PostAsync(genreDto);
            return CreatedAtAction(nameof(GetGenre), new { id = genre.Id }, genre);
        }
    }
}
