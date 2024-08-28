using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SewingMachineManagement.Application.Common.Options;
using SewingMachineManagement.Infrastructure.Persistence;

namespace SewingMachineManagement.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection BindAndValidateOptions<TOptions>(this IServiceCollection services,
        string sectionName) where TOptions : class
    {
        services.AddOptions<TOptions>()
            .BindConfiguration(sectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        return services;
    }

    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services,
        IConfiguration configuration)
    {
        var dbUrl = configuration.GetRequiredSection(ConnectionStringsOptions.SectionName)
            .GetValue<string>(nameof(ConnectionStringsOptions.SewingMachineManagementDb));

        ArgumentNullException.ThrowIfNull(dbUrl);
        
        var optionsBuilder = new DbContextOptionsBuilder<SewingMachineManagementDbContext>();
        optionsBuilder.UseOracle(dbUrl);

        using (var dbContext = new SewingMachineManagementDbContext(optionsBuilder.Options))
        {
            Console.WriteLine(dbContext.Database.CanConnect());
        }

        services.AddDbContext<SewingMachineManagementDbContext>(
            dbContextOptions => dbContextOptions
                .UseOracle(dbUrl)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .UseEnumCheckConstraints()
        );

        return services;
    }

    public static IServiceCollection AddJwtAuth(this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection(JwtOAuthOptions.SectionName).Get<JwtOAuthOptions>();

        ArgumentNullException.ThrowIfNull(jwtOptions);
        
        services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = jwtOptions.Authority;
                options.Audience = jwtOptions.Audience;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Authority,
                    ValidAudience = jwtOptions.Audience
                };
                // If using Keycloak, you might need to set this
                options.RequireHttpsMetadata = false;
            });

        return services;
    }
}