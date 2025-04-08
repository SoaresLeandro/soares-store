using Microsoft.Extensions.DependencyInjection;
using SoaresStore.Domain.Repositories;
using SoaresStore.Infrastructure.Repositories;

namespace SoaresStore.Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
