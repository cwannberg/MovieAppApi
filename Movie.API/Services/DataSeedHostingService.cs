
using Bogus;
using Microsoft.EntityFrameworkCore;
using Movie.API.Entities;

namespace Movie.API.Services
{
    public class DataSeedHostingService : IHostedService 
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<DataSeedHostingService> logger;

        public DataSeedHostingService(IServiceProvider serviceProvider, ILogger<DataSeedHostingService> logger)
        {
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = serviceProvider.CreateScope();
            var env = serviceProvider.GetRequiredService<IWebHostEnvironment>();
            if (!env.IsDevelopment()) return;
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            if (await context.Actors.AnyAsync(cancellationToken)) return;

            try
            {
                IEnumerable<Actor> actors = GenerateActors(5);
                await context.Actors.AddRangeAsync(actors, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                logger.LogInformation("Actorseed complete.");
            }
            catch (Exception ex)
            {
                logger.LogError($"Data seed with error: {ex.Message}");
            }

            if (await context.Movies.AnyAsync(cancellationToken)) return;

            try
            {
                IEnumerable<MovieFilm> movies = GenerateMovies(5);
                await context.Movies.AddRangeAsync(movies, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);
                logger.LogInformation("Movieseed complete.");
            }
            catch (Exception ex)
            {
                logger.LogError($"Data seed with error: {ex.Message}");
            }
            if (await context.Genres.AnyAsync(cancellationToken)) return;

            try
            {
                Genre genre = GenerateGenre();
                await context.SaveChangesAsync(cancellationToken);
                logger.LogInformation("Genreseed complete.");
            }
            catch (Exception ex)
            {
                logger.LogError($"Data seed with error: {ex.Message}");
            }
        }
        private IEnumerable<Actor> GenerateActors(int numberOfActors)
        {
            var faker = new Faker<Actor>("sv").Rules((f, a) =>
            {
                a.Name = f.Person.FullName;
                a.BirthYear = f.Random.Int(1940, 2010);
                a.Movies = GenerateMovies(f.Random.Int(min: 1, max: 5));
            });
            return faker.Generate(numberOfActors);
        }

        private ICollection<MovieFilm> GenerateMovies(int numberOfMovies)
        {
            string[] movieNames = ["Shrek", "IT", "Up", "Psycho", "Jaws"];

            var faker = new Faker<MovieFilm>("sv").Rules((f, m) =>
            {
                m.Title = movieNames[f.Random.Int(0, movieNames.Length -1)];
                m.Year = f.Random.Int(min: 1955, max: 2025);
                m.Genre = GenerateGenre();
            });

            return faker.Generate(numberOfMovies);
        }
        private Genre GenerateGenre()
        {
            string[] names = { "Drama", "Kids", "Documentary", "Romance", "Horror" };

            var faker = new Faker<Genre>("sv")
                .RuleFor(m => m.Name, f => names[f.Random.Int(0, names.Length - 1)]);

            return faker.Generate();
        }
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
    
}
