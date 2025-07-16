using Movie.Core.DomainContracts;

namespace Movie.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    public IMovieRepository Movies => throw new NotImplementedException();

    public IReviewRepository Reviews => throw new NotImplementedException();

    public IActorRepository Actors => throw new NotImplementedException();

    public Task CompleteAsync()
    {
        throw new NotImplementedException();
    }
}
