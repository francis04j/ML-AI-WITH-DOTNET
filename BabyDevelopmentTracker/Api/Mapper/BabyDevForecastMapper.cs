using System.Reflection;
using Api.Entities;
using Api.Models;
using Mapster;
using MapsterMapper;

namespace Api.Mapper;

public static class MapsterConfig
{
    
        public static IServiceCollection AddMappings(this IServiceCollection services) {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
    
}

public class BabyDevForecastMapper
{
    
}