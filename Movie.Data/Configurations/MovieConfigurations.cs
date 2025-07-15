using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.Core.Entities;

namespace Movie.Data.Configurations;

public class MovieConfigurations : IEntityTypeConfiguration<MovieFilm>
{
    public void Configure(EntityTypeBuilder<MovieFilm> builder)
    {
        builder.HasKey(m => m.Id);

        builder.HasOne(m => m.Genre)
               .WithMany()
               .HasForeignKey(m => m.GenreId);

        builder.HasOne(m => m.MovieDetails)
               .WithOne(md => md.Movie)
               .HasForeignKey<MovieDetails>(md => md.MovieId);

        builder.HasMany(m => m.Reviews)
               .WithOne(r => r.Movie)
               .HasForeignKey(r => r.MovieId);

        builder.HasMany(m => m.Actors)
               .WithMany(a => a.Movies);
    }
}