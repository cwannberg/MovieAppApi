using AutoMapper;
using Movie.Core.Dtos;
using Movie.Core;
using Movie.Core.Entities;
using Movie.Services.Contracts;

namespace Movie.Services
{
    public class ActorService : IActorService
    {
        private IUnitOfWork uow;
        private readonly IMapper mapper;

        public ActorService(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ActorDto>> GetAllAsync(int pageNumber, int pageSize)
        {
            var actors = await uow.ActorRepository.GetAllAsync(pageNumber, pageSize);
            return mapper.Map<IEnumerable<ActorDto>>(actors);
        }
        public async Task<ActorDto> PostAsync(ActorCreateDto actorDto)
        {
            var actor = mapper.Map<Actor>(actorDto);
                await uow.ActorRepository.PostAsync(actor);
                await uow.CompleteAsync();

                return mapper.Map<ActorDto>(actorDto);
            
        }
        public async Task DeleteAsync(int id) => await uow.ActorRepository.DeleteAsync(id);
        public async Task<ActorDto> GetAsync(int id) => mapper.Map<ActorDto>(await uow.ActorRepository.GetAsync(id));
        public async Task PutAsync(int id, ActorDto actorDto) => await uow.ActorRepository.PutAsync(id, mapper.Map<Actor>(actorDto));
        public async Task<PagedResult<ActorDto>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var totalItems = await uow.ActorRepository.GetTotalCountAsync();
            var actors = await uow.ActorRepository.GetAllAsync(pageNumber, pageSize);
            var actorsDto = mapper.Map<IEnumerable<ActorDto>>(actors);
            return new PagedResult<ActorDto>
            {
                Data = actorsDto,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };
        }
    }
}