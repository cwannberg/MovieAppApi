using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dtos;
using Movie.Services.Contracts;
using System.Threading.Tasks;

namespace Movie.Presentation.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public MoviesController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovie()
        {
            return Ok(await serviceManager.MovieService.GetAllAsync());
        }
        
        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await serviceManager.MovieService.GetAsync(id);
            return movie;
        }

        // PUT: api/Movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, [FromBody] MovieDto movieDto)
        {
            await serviceManager.MovieService.PutAsync(id, movieDto);

            return NoContent();
        }
        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieDto>> PostMovie([FromBody] MovieCreateDto movieCreateDto)
        {
            var createdMovieDto = await serviceManager.MovieService.PostAsync(movieCreateDto);
            return CreatedAtAction(nameof(GetMovie), new { id = createdMovieDto.Id }, createdMovieDto);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {

            await serviceManager.MovieService.DeleteAsync(id);

            return NoContent();
        }
    }
}
