﻿using Movie.Core.DomainContracts;

public interface IUnitOfWork
{
    IMovieRepository Movies { get; }
    IReviewRepository Reviews { get; }
    IActorRepository Actors { get; }
    Task CompleteAsync();
}
