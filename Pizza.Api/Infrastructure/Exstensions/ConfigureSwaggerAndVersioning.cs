using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Pizza.Api.Infrastructure.Exstensions
{
    public static class ConfigureSwaggerAndVersioning
    {
        public static void AddConfiguredSwagger(this IServiceCollection services)
        {
            services.AddSwaggerExamplesFromAssemblyOf<Program>();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(opts =>
            {
                opts.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pizza API",
                    Version = "v1",
                    Description = "Api for Pizza Project",
                });

                opts.ExampleFilters();
            });
        }

        public static void AddCustomVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opts =>
            {
                opts.AssumeDefaultVersionWhenUnspecified = true;
                opts.DefaultApiVersion = new ApiVersion(1, 0);
                opts.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddVersionedApiExplorer(opts =>
            {
                opts.GroupNameFormat = "'v'VVV";
                opts.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
