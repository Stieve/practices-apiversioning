using System;
using Microsoft.Extensions.DependencyInjection;

namespace NCore.Practices.ApiVersioning.SwaggerExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNCoreDefaultVersionedSwaggerGen(this IServiceCollection services, Action<DefaultSwaggerGenOptions> configure = null)
        {
            var builder = services.AddOptions<DefaultSwaggerGenOptions>();
            if (configure != null)
                builder.Configure(configure);

            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();
            return services;
        }
    }
}
