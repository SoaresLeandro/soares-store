using MediatR;
using SoaresStore.Domain.Abstractions;

namespace SoaresStore.Application.UseCases.Products.Create
{
    public sealed record Command(string Title) : IRequest<Result<Response>>;
}
