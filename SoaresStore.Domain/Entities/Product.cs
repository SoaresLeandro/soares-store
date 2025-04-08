using SoaresStore.Domain.Entities.Abstractions;

namespace SoaresStore.Domain.Entities
{
    public class Product : Entity
    {
        public string Title { get; set; } = string.Empty;
    }
}
