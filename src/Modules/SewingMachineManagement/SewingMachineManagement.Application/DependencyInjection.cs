using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace SewingMachineManagement.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

        return services;
    }
}