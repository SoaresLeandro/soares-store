using SoaresStore.Domain.Entities.Abstractions;

namespace SoaresStore.Domain.Repositories
{
    public interface IRepository<T> where T : Entity;
}
