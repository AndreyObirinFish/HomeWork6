using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyCity.Core.Abstractions.Services;
using MyCity.Services;
using MyCity.WebHost.Mapper;

namespace MyCity.WebHost.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile<MapperProfile>(); });

            var mapper = mappingConfig.CreateMapper();
            return services.AddSingleton(mapper);
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<IRoleService, RoleService>()
                    .AddScoped<IUserService, UserService>()
                    .AddScoped<IMediaFileService, MediaFileService>()
                    .AddScoped<IReviewService, ReviewService>()
                    .AddScoped<ICustomStopService, CustomStopService>()
                    .AddScoped<IPointOfInterestService, PointOfInterestService>()
                    .AddScoped<IRouteService,RouteService>()
                ;
        }
    }
}
