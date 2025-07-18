﻿using System.ComponentModel.DataAnnotations;

namespace Movie.Core.Dtos;

public class ReviewDto
{
    public int Id { get; set; }
    public string ReviewerName { get; set; } = null!;
    [Range(1, 5)]
    [Required]
    public int Rating { get; set; }
}