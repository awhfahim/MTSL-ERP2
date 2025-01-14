using System.ComponentModel.DataAnnotations;

namespace SewingMachineManagement.Application.Common.Options;

public record JwtOAuthOptions
{
    public const string SectionName = "JwtOAuthOptions";
    [Required] public required string Authority { get; init; }
    [Required] public required string Audience { get; init; }
    [Required] public required string ClientId { get; init; }
}