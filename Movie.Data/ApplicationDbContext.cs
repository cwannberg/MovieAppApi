using Microsoft.EntityFrameworkCore;
using Movie.Core.Entities;
using Movie.Data.Configurations;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public DbSet<Actor> Actors { get; set; } = default!;
    public DbSet<MovieFilm> Movies { get; set; } = default!;
    public DbSet<Review> Reviews { get; set; } = default!;
    public DbSet<Genre> Genres { get; set; } = default!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ActorConfigurations());
        modelBuilder.ApplyConfiguration(new GenreConfigurations());
        modelBuilder.ApplyConfiguration(new MovieConfigurations());
        modelBuilder.ApplyConfiguration(new MovieDetailsConfigurations());
        modelBuilder.ApplyConfiguration(new ReviewConfigurations());
        ConfigureActorMovie(modelBuilder);
    }
    private void ConfigureActorMovie(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>()
            .HasMany(a => a.Movies)
            .WithMany(m => m.Actors)
            .UsingEntity<Dictionary<string, object>>(
                "ActorMovie",
                j => j.HasOne<MovieFilm>().WithMany().HasForeignKey("MoviesId"),
                j => j.HasOne<Actor>().WithMany().HasForeignKey("ActorsId"),
                j =>
                {
                    j.HasKey("ActorsId", "MoviesId");
                    j.ToTable("ActorMovie");
                    j.HasData(
                        new { ActorsId = 1, MoviesId = 4 },
                        new { ActorsId = 2, MoviesId = 1 },
                        new { ActorsId = 3, MoviesId = 3 },
                        new { ActorsId = 4, MoviesId = 2 },
                        new { ActorsId = 5, MoviesId = 3 }
                    );
                });
    }


}
