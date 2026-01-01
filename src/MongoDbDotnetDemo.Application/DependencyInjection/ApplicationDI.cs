using Microsoft.Extensions.DependencyInjection;
using MongoDbDotnetDemo.Application.Interfaces;
using MongoDbDotnetDemo.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Application.DependencyInjection
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register application services here
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
