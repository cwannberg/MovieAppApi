﻿namespace Movie.Services.Contracts;
public interface IServiceManager
{
    IMovieService MovieService { get; }
    IActorService ActorService { get; }
    IReviewService ReviewService { get; }
    IGenreService GenreService { get; }
}