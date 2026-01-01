using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbDotnetDemo.Application.Common;
using MongoDbDotnetDemo.Application.DTOs.Product;
using MongoDbDotnetDemo.Application.Interfaces;
using MongoDbDotnetDemo.Domain.Entities;

namespace MongoDbDotnetDemo.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public sealed class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var products = await _productService.GetAllAsync(ct);

            return Ok(ApiResponse<IReadOnlyList<Product>>.Ok(
                products,
                "Products fetched successfully"));
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(string id, CancellationToken ct)
        {
            var product = await _productService.GetByIdAsync(id, ct);

            return Ok(ApiResponse<Product>.Ok(
                product,
                "Product fetched successfully"));
        }

        /// <summary>
        /// Create a new product
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductDto dto,
            CancellationToken ct)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };

            var productId = await _productService.CreateAsync(product, ct);

            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = productId
                },
                ApiResponse<string>.Ok(
                    productId,
                    "Product created successfully"));
        }

        /// <summary>
        /// Update an existing product
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(
            string id,
            [FromBody] UpdateProductDto dto,
            CancellationToken ct)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                IsActive = dto.IsActive
            };

            await _productService.UpdateAsync(id, product, ct);

            return Ok(ApiResponse<string>.Ok(
                "SUCCESS",
                "Product updated successfully"));
        }

        /// <summary>
        /// Delete (soft delete) a product
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(string id, CancellationToken ct)
        {
            await _productService.DeleteAsync(id, ct);

            return Ok(ApiResponse<string>.Ok(
                "SUCCESS",
                "Product deleted successfully"));
        }
    }
}
