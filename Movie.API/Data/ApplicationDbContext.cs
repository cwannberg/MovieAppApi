using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.API.Entities;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; } = default!;
        public DbSet<MovieFilm> Movies { get; set; } = default!;
        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<MovieDetails> MovieDetails { get; set; } = default!;
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

public DbSet<Movie.API.Entities.Review> Review { get; set; } = default!;
    }
