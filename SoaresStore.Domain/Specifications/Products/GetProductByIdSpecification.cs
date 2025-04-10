using SoaresStore.Domain.Abstractions;
using SoaresStore.Domain.Entities;
using System.Linq.Expressions;

namespace SoaresStore.Domain.Specifications.Products
{
    public class GetProductByIdSpecification(Guid id) : Specification<Product>
    {
        public override Expression<Func<Product, bool>> ToExpression() =>
            product => product.Id.Equals(id);
    }
}
