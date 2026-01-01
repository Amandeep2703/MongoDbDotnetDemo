using MongoDbDotnetDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Application.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct);
        Task<Product> GetByIdAsync(string id, CancellationToken ct);
        Task<string> CreateAsync(Product product, CancellationToken ct);
        Task UpdateAsync(string id, Product product, CancellationToken ct);
        Task DeleteAsync(string id, CancellationToken ct);
    }
}
