using MediatR;
using SoaresStore.Domain.Abstractions;
using SoaresStore.Domain.Repositories;

namespace SoaresStore.Application.UseCases.Products.GetById
{
    public sealed class Handler(IProductRepository repository) : IRequestHandler<Command, Result<Response>>
    {
        public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id, cancellationToken);

            return product is null ?
                Result.Failure<Response>(new Error("404", "Product Not Found")) :
                Result.Success<Response>(new Response(product.Id, product.Title));
        }
    }
}
