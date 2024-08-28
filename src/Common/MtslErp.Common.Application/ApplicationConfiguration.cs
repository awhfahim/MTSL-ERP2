using Microsoft.Extensions.DependencyInjection;

namespace MtslErp.Common.Application;

public static class ApplicationConfiguration
{
    public static void AddCommonApplicationServices(this IServiceCollection services)
    {
        services.AddLogging();
    }
}
