using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace YoutubeApi.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(assembly));

            var mapperAssembly = Assembly.Load("YoutubeApi.Mapper");

            services.AddAutoMapper(
                Assembly.GetExecutingAssembly(),
                mapperAssembly
            );
        }
    }
}