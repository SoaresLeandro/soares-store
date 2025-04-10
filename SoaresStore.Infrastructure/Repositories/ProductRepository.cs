using Microsoft.EntityFrameworkCore;
using SoaresStore.Domain.Abstractions;
using SoaresStore.Domain.Entities;
using SoaresStore.Domain.Repositories;
using SoaresStore.Infrastructure.Data;

namespace SoaresStore.Infrastructure.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> DeleteAsync(Product product, CancellationToken cancellationToken)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken) =>
            context.Products.AsNoTracking().ToList();

        public async Task<Product?> GetByIdAsync(Specification<Product> specification, CancellationToken cancellationToken) =>
            await context.Products.Where(specification.ToExpression()).FirstOrDefaultAsync(cancellationToken);

        public async Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();

            return product;
        }
    }
}
