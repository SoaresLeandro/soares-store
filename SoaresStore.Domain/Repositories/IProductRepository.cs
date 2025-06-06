﻿using SoaresStore.Domain.Abstractions;
using SoaresStore.Domain.Entities;

namespace SoaresStore.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product?> GetByIdAsync(Specification<Product> specification, CancellationToken cancellationToken);

        Task<List<Product>> GetAllAsync(CancellationToken cancellationToken);

        Task<Product> CreateAsync(Product product, CancellationToken cancellationToken);

        Task<Product> UpdateAsync(Product product, CancellationToken cancellationToken);

        Task<Product> DeleteAsync(Product product, CancellationToken cancellationToken);
    }
}
