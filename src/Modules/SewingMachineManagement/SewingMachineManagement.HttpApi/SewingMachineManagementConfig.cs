using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SewingMachineManagement.Application.Common.Options;
using SewingMachineManagement.HttpApi.ClaimTransformers;
using SewingMachineManagement.Infrastructure.Extensions;

namespace SewingMachineManagement.HttpApi;

public static class SewingMachineManagementConfig
{
    public static IServiceCollection RegisterSewingMachineManagementModule(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabaseConfig(configuration);
        services.AddSingleton<IClaimsTransformation, KeycloakRoleTransformation>();
        services.BindAndValidateOptions<JwtOAuthOptions>(JwtOAuthOptions.SectionName);
        services.AddJwtAuth(configuration);

        var appOptions = configuration.GetRequiredSection(AppOptions.SectionName).Get<AppOptions>();

        ArgumentNullException.ThrowIfNull(appOptions);

        services.AddCors(options =>
        {
            options.AddPolicy(nameof(AppOptions.AllowedOriginsForCors), x => x
                .WithOrigins(appOptions.AllowedOriginsForCors)
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );
        });


        return services;
    }

    public static WebApplication UseSewingMachineManagementModule(this WebApplication webApplication)
    {
        webApplication.UseCors(nameof(AppOptions.AllowedOriginsForCors));
        return webApplication;
    }
}