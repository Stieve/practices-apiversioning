using System;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.DependencyInjection;

namespace NCore.Practices.ApiVersioning.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNCoreDefaultVersionByNamespace(this IServiceCollection services, Action<DefaultVersionByNamespaceOptions> configure = null)
        {
            var defaultOptions = new DefaultVersionByNamespaceOptions();
            configure?.Invoke(defaultOptions);

            services.AddOptions<DefaultVersionByNamespaceOptions>().Configure(configure);
            services.AddApiVersioning(options =>
            {
                options.Conventions.Add(new VersionByNamespaceConvention());
                options.AssumeDefaultVersionWhenUnspecified = defaultOptions.AssumeDefaultVersionWhenUnspecified;
                options.DefaultApiVersion = defaultOptions.DefaultApiVersion;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = defaultOptions.GroupNameFormat;
                options.DefaultApiVersion = defaultOptions.DefaultApiVersion;
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}