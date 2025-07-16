using Movie.Core.DomainContracts;
using Movie.Core.Entities;

namespace Movie.Data.Repositories;

public class ReviewRepository : IReviewRepository
{
    private ApplicationDbContext _context { get; }

    public ReviewRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task DeleteReview(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Review>> GetReviewAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Review> GetReviewAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task PostReviewAsync(Review review)
    {
        throw new NotImplementedException();
    }

    public Task PutReviewAsync(int id, Review review)
    {
        throw new NotImplementedException();
    }
}
