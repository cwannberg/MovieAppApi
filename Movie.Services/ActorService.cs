using Movie.Core.DomainContracts;
using Movie.Services.Contracts;

namespace Movie.Services
{
    public class ActorService : IActorService
    {
        private IUnitOfWork uow;
        public ActorService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}