using MediatR;
using SoaresStore.Domain.Abstractions;
using SoaresStore.Domain.Entities;
using SoaresStore.Domain.Repositories;

namespace SoaresStore.Application.UseCases.Products.Create
{
    public class Handler(IProductRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<Command, Result<Response>>
    {
        public async Task<Result<Response>> Handle(Command request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Id = new Guid(),
                Title = request.Title
            };

            await repository.CreateAsync(product, cancellationToken);
            await unitOfWork.CommitAsync();

            return Result.Success(new Response("Produto criado com sucesso"));
        }
    }
}
