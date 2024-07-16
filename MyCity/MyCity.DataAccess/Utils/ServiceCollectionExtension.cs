using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyCity.Core.Abstractions.Repositories;
using MyCity.Core.Abstractions;
using MyCity.Core.Domain;
using Microsoft.EntityFrameworkCore;
using MyCity.DataAccess.Repositories;
using MyCity.Dtos.PointOfInterestDtos;

namespace MyCity.DataAccess.Utils
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            /*
            var connectionString = configuration.GetValue<string>("ConnectionStrings:Main");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));
            */
            var pgConnectionString = configuration.GetValue<string>("ConnectionStrings:MyCityDb");
            services.AddDbContext<ApplicationDbContext>(options => options
                .UseNpgsql(pgConnectionString)
                .UseSnakeCaseNamingConvention()
                );

            services.AddScoped<IMigrator, Migrator>();
            return services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                    .AddScoped<IRepository<User>, GenericRepository<User, ApplicationDbContext>>()
                    .AddScoped<IRepository<Role>, GenericRepository<Role, ApplicationDbContext>>()
                    .AddScoped<IRepository<MediaFile>, GenericRepository<MediaFile, ApplicationDbContext>>()
                    .AddScoped<IRepository<Review>, GenericRepository<Review, ApplicationDbContext>>()
                    .AddScoped<IRepository<PointOfInterest>, GenericRepository<PointOfInterest, ApplicationDbContext>>()
                    .AddScoped<IRepository<Route>, GenericRepository<Route, ApplicationDbContext>>()
                    .AddScoped<IRepository<CustomStop>, GenericRepository<CustomStop, ApplicationDbContext>>();
        }
    }
}
