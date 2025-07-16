using Movie.Core.Entities;

namespace Movie.Core.DomainContracts;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> GetReviewAsync();
    Task<Review> GetReviewAsync(int id);
    Task PutReviewAsync(int id, Review review);
    Task PostReviewAsync(Review review);
    Task DeleteReview(int id);
}
