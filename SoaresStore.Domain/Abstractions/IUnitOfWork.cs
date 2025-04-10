namespace SoaresStore.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
