﻿using System.ComponentModel.DataAnnotations;

namespace Movie.Core.Dtos;

public record MovieCreateDto {
    public int Id { get; set; }
    [Required]
    public string Title { get; init; } = null!;
    [Required]
    public int Year { get; init; }
    [Range(1, 4)]
    public string? Synopsis { get; init; } 
    public string? Language { get; init; }
    public int? Budget { get; init; }
    public string? Duration { get; init; }
    public string? Genre { get; init; }
    public int? GenreId { get; init; }
    public IEnumerable<MovieDto>? Movies { get; init; } = new List<MovieDto>();
    public ActorDto? ActorDto { get; init; }
    public IEnumerable<ActorDto>? Actors { get; init; } = new List<ActorDto>();
    public IEnumerable<ReviewDto>? Reviews { get; init; } = new List<ReviewDto>();
};
