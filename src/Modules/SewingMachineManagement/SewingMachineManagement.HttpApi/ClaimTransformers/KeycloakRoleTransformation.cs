using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using SewingMachineManagement.Domain.DataTransferObjects.Request;

namespace SewingMachineManagement.HttpApi.ClaimTransformers;

public class KeycloakRoleTransformation : IClaimsTransformation
{
    private readonly JsonSerializerOptions _serializerOptions = new()
        { PropertyNameCaseInsensitive = true };

    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var result = principal.Clone();
        if (result.Identity is not ClaimsIdentity identity)
        {
            return Task.FromResult(result);
        }

        var resourceAccessValue = principal.FindFirst("resource_access")?.Value;

        if (string.IsNullOrWhiteSpace(resourceAccessValue))
        {
            return Task.FromResult(result);
        }

        var clients = JsonSerializer.Deserialize<KeycloakJwtClientRoles>(resourceAccessValue, _serializerOptions);
        if (clients is null)
        {
            return Task.FromResult(result);
        }

        foreach (var (_, value) in clients)
        {
            foreach (var role in value.Roles)
            {
                identity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, role));
            }
        }

        return Task.FromResult(result);
    }
}