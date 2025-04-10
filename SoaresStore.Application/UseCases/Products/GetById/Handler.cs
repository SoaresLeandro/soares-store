using MediatR;
using SoaresStore.Domain.Abstractions;
using SoaresStore.Domain.Repositories;
using SoaresStore.Domain.Specifications.Products;

namespace SoaresStore.Application.UseCases.Products.GetById
{
    public sealed class Handler(IProductRepository repository) : IRequestHandler<Command, Result<Response>>
    {
        public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            var specification = new GetProductByIdSpecification(request.Id);
            var product = await repository.GetByIdAsync(specification, cancellationToken);

            return product is null ?
                Result.Failure<Response>(new Error("404", "Product Not Found")) :
                Result.Success<Response>(new Response(product.Id, product.Title));
        }
    }
}
