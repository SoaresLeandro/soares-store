using SoaresStore.Domain.Abstractions;

namespace SoaresStore.Domain.Repositories
{
    public interface IRepository<T> where T : Entity;
}
