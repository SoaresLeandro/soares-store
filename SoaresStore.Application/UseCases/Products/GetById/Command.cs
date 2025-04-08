using MediatR;
using SoaresStore.Domain.Abstractions;

namespace SoaresStore.Application.UseCases.Products.GetById
{
    public sealed record Command(Guid Id) : IRequest<Result<Response>>;
}
