using MongoDbDotnetDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Infrastructure.Repositories.Products
{
    public interface IProductRepository
    {
        Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct);
        Task<Product?> GetByIdAsync(string id, CancellationToken ct);
        Task CreateAsync(Product product, CancellationToken ct);
        Task UpdateAsync(Product product, CancellationToken ct);
        Task SoftDeleteAsync(Product product, CancellationToken ct);
    }
}
