using Microsoft.AspNetCore.Mvc;
using Movie.Core.Dtos;
using Movie.Services.Contracts;

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
        /*
                // PUT: api/Movies/5
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPut("{id}")]
                public async Task<IActionResult> PutMovie(int id, MovieFilm movie)
                {
                    if (id != movie.Id)
                    {
                        return BadRequest();
                    }

                    context.Entry(movie).State = EntityState.Modified;

                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MovieExists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                    return NoContent();
                }

                // POST: api/Movies
                // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
                [HttpPost]
                public async Task<ActionResult<MovieFilm>> PostMovie(MovieFilm movie)
                {
                    context.Movies.Add(movie);
                    await context.SaveChangesAsync();

                    return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
                }

                // DELETE: api/Movies/5
                [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteMovie(int id)
                {
                    var movie = await context.Movies.FindAsync(id);
                    if (movie == null)
                    {
                        return NotFound();
                    }

                    context.Movies.Remove(movie);
                    await context.SaveChangesAsync();

                    return NoContent();
                }

                private bool MovieExists(int id)
                {
                    return context.Movies.Any(e => e.Id == id);
                }*/
    }
}
