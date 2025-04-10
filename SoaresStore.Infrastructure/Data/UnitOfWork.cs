using SoaresStore.Domain.Abstractions;

namespace SoaresStore.Infrastructure.Data
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}
