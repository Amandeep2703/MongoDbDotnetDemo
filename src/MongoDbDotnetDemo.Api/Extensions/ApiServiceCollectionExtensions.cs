using Microsoft.OpenApi.Models;

namespace MongoDbDotnetDemo.API.Extensions
{
    public static class ApiServiceCollectionExtensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            //enable the swagger in api project
            // Controllers
            services.AddControllers();

            // Swagger / OpenAPI
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MongoDbDotnetDemo API",
                    Version = "v1",
                    Description = "Production-level Web API using .NET and MongoDB"
                });
            });


            return services;
        }
    }
}
