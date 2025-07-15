using Microsoft.EntityFrameworkCore;
using Movie.API.Data.Configurations;
using Movie.API.Entities;

public class ApplicationDbContext : DbContext
{
    public DbSet<Actor> Actors { get; set; } = default!;
    public DbSet<MovieFilm> Movies { get; set; } = default!;
    public DbSet<Review> Review { get; set; } = default!;
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
    }
}
