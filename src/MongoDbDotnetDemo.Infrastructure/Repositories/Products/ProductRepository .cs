using MongoDB.Driver;
using MongoDbDotnetDemo.Domain.Entities;
using MongoDbDotnetDemo.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Infrastructure.Repositories.Products
{
    public class ProductRepository: IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;
        public ProductRepository(MongoDbContext context)
        {
            _collection = context.Database.GetCollection<Product>(MongoCollections.Products);
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct) =>
            await _collection.Find(x => x.IsDeleted == false).ToListAsync(ct);

        public async Task<Product?> GetByIdAsync(string id, CancellationToken ct) =>
            await _collection.Find(x => x.Id == id && x.IsDeleted==false)
                             .FirstOrDefaultAsync(ct);

        public Task CreateAsync(Product product, CancellationToken ct) =>
            _collection.InsertOneAsync(product, cancellationToken: ct);

        public Task UpdateAsync(Product product, CancellationToken ct) =>
            _collection.ReplaceOneAsync(x => x.Id == product.Id, product, cancellationToken: ct);

        public Task SoftDeleteAsync(Product product, CancellationToken ct)
        {
            product.IsDeleted = true;
            product.IsActive = false;
            product.UpdatedOn = DateTime.UtcNow;
            product.UpdatedBy = "SYSTEM";

            return UpdateAsync(product, ct);
        }
    }
}
