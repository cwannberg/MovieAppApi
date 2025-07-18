using AutoMapper;
using Movie.Core.Dtos;
using Movie.Core.Entities;

namespace Movie.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Actor, ActorDto>();
            CreateMap<ActorCreateDto, Actor>();
            CreateMap<MovieFilm, MovieDto>();
            CreateMap<MovieFilm, MovieCreateDto>();
            CreateMap<MovieCreateDto, MovieFilm>();
            CreateMap<MovieFilm, ActorsMoviesDto>();
            CreateMap<MovieFilm, ActorsMoviesDto>().ReverseMap();
            CreateMap<Genre, GenreDto>();
            CreateMap<MovieDetails, MovieDetailDto>();
            CreateMap<Review, ReviewDto>();
        }
    }
}
