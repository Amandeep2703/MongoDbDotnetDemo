using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDbDotnetDemo.Infrastructure.Config;
using MongoDbDotnetDemo.Infrastructure.Mappings;
using MongoDbDotnetDemo.Infrastructure.Persistence;
using MongoDbDotnetDemo.Infrastructure.Repositories.Products;

namespace MongoDbDotnetDemo.Infrastructure.DependencyInjection
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            // ✅ Correct usage
            services.Configure<MongoDbSettings>(
                configuration.GetSection("MongoDb"));

            services.AddSingleton<MongoDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
