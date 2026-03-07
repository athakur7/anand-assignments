using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFDemo
{
    class ProductRepository2 : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository2(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC AddProduct @p0, @p1, @p2",
                product.Name, product.Price, product.CategoryId);
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC DeleteProduct {id}");
        }

        public async Task<List<Product>> GetAllAsync()
        {
           return await _context.Products.FromSqlRaw("EXEC GetAllProducts").ToListAsync();
        }

        public Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            
            var products = _context.Products.FromSqlRaw("EXEC GetProductsByCategory @p0", categoryId).ToList();
            return Task.FromResult(products);
        }

        public Task<Product?> GetByIdAsync(int id)
        {
            var product = _context.Products.FromSqlRaw("EXEC GetProductById @p0", id).AsEnumerable().FirstOrDefault();
            return Task.FromResult(product);
        }

        public async Task UpdateAsync(Product product)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateProduct @p0, @p1, @p2, @p3",
                product.Id, product.Name, product.Price, product.CategoryId);
        }
    }
}
