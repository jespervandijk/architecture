using Application.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();

        return services;
    }
}