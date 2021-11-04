using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace NCore.Practices.ApiVersioning.SwaggerExtensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNCoreDefaultVersionedSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{description.ApiVersion}");
                }
            });
            return app;
        }
    }
}