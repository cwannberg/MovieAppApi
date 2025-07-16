using Microsoft.EntityFrameworkCore;
using Movie.Core.DomainContracts;
using Movie.Data;
using Movie.Data.Repositories;
using Movie.Services;

namespace Movie.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext")
                ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly("Movie.Data")));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddHostedService<DataSeedHostingService>();

            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapperProfile>());
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
