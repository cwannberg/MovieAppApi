using AutoMapper;
using Movie.Core.Dtos;
using Movie.Core.Entities;

namespace Movie.API.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Actor, ActorDto>();
            CreateMap<MovieFilm, MovieDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<MovieDetails, MovieDetailDto>();
            CreateMap<Review, ReviewDto>();
        }
    }
}
