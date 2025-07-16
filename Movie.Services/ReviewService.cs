using Movie.Services.Contracts;

namespace Movie.Services
{
    public class ReviewService : IReviewService
    {
        private IUnitOfWork uow;

        public ReviewService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}