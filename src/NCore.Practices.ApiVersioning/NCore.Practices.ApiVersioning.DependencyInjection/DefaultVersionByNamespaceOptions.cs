using Microsoft.AspNetCore.Mvc;

namespace NCore.Practices.ApiVersioning.DependencyInjection
{
    public class DefaultVersionByNamespaceOptions
    {
        public bool AssumeDefaultVersionWhenUnspecified { get; set; } = true;
        public ApiVersion DefaultApiVersion { get; set; } = new ApiVersion(1, 0);
        public string GroupNameFormat { get; set; } = "'v'VVV";
    }
}