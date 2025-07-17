using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dtos;
using Movie.Core.Entities;
using Movie.Services.Contracts;
using System.Threading.Tasks;

namespace Movie.Presentation.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public GenreController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenre()
        {
            return Ok(await serviceManager.GenreService.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<GenreDto>> PostGenre([FromBody] GenreDto genreDto)
        {
            var genre = await serviceManager.GenreService.PostAsync(genreDto);
            return CreatedAtAction(nameof(GetGenre), new { id = genre.Id }, genre);
        }
    }
}
