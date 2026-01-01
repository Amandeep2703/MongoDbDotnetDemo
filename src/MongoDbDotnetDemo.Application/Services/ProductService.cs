using MongoDbDotnetDemo.Application.Common.Exceptions;
using MongoDbDotnetDemo.Application.Interfaces;
using MongoDbDotnetDemo.Domain.Entities;
using MongoDbDotnetDemo.Infrastructure.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDotnetDemo.Application.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken ct)
        {
            return _productRepository.GetAllAsync(ct);
        }

        public async Task<Product> GetByIdAsync(string id, CancellationToken ct)
        {
            var product = await _productRepository.GetByIdAsync(id, ct);

            if (product is null)
                throw new NotFoundException($"Product with id '{id}' was not found.");

            return product;
        }

        public async Task<string> CreateAsync(Product product, CancellationToken ct)
        {
            product.CreatedOn = DateTime.UtcNow;
            product.CreatedBy = "SYSTEM";
            product.IsActive = true;
            product.IsDeleted = false;

            await _productRepository.CreateAsync(product, ct);

            // 🔥 RETURN GENERATED ID
            return product.Id;
        }

        public async Task UpdateAsync(string id, Product updatedProduct, CancellationToken ct)
        {
            var existingProduct = await GetByIdAsync(id, ct);

            existingProduct.Name = updatedProduct.Name ?? existingProduct.Name;
            existingProduct.Price = updatedProduct.Price ?? existingProduct.Price;
            existingProduct.IsActive = updatedProduct.IsActive ?? existingProduct.IsActive;

            existingProduct.UpdatedOn = DateTime.UtcNow;
            existingProduct.UpdatedBy = "SYSTEM";

            await _productRepository.UpdateAsync(existingProduct, ct);
        }

        public async Task DeleteAsync(string id, CancellationToken ct)
        {
            var product = await GetByIdAsync(id, ct);

            product.IsDeleted = true;
            product.IsActive = false;
            product.UpdatedOn = DateTime.UtcNow;
            product.UpdatedBy = "SYSTEM";

            await _productRepository.SoftDeleteAsync(product, ct);
        }
    }

}
