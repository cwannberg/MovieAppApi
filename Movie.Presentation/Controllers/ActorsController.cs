using Microsoft.AspNetCore.Mvc;
using Movie.Core;
using Movie.Core.Dtos;
using Movie.Services.Contracts;
using System.Text.Json;

namespace Movie.Presentation.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;
        const int maxPageSize = 100;

        public ActorsController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<PagedResult<IEnumerable<ActorDto>>>> GetActor(int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxPageSize)
                pageSize = maxPageSize;
            var result = await serviceManager.ActorService.GetPagedAsync(pageNumber, pageSize);

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

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDto>> GetActor(int id)
        {
            var actor = await serviceManager.ActorService.GetAsync(id);
            return actor;
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(int id, [FromBody] ActorDto actorDto)
        {
            await serviceManager.ActorService.PutAsync(id, actorDto);

            return NoContent();
        }
        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<ActorDto>> PostActor([FromBody] ActorCreateDto actorCreateDto)
        {
            var createActorDto = await serviceManager.ActorService.PostAsync(actorCreateDto);
            return CreatedAtAction(nameof(GetActor), new { id = createActorDto.Id }, createActorDto);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(int id)
        {

            await serviceManager.ActorService.DeleteAsync(id);

            return NoContent();
        }
    }
}
