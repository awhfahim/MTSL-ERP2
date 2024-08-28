using System.Security.Claims;

namespace SewingMachineManagement.Application.Providers;

public interface IJwtProvider
{
    (string token, DateTime duration) GenerateJwt(Dictionary<string, object> claims);
    (string token, DateTime duration) GenerateJwt(IEnumerable<Claim> claims);
}
