﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.API.Entities;

namespace Movie.API.Data.Configurations;

public class ReviewConfigurations : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasOne(r => r.Movie)
               .WithMany(m => m.Reviews)
               .HasForeignKey(r => r.MovieId);
    }
}
