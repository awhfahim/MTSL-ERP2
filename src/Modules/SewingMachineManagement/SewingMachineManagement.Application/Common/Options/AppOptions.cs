using System.ComponentModel.DataAnnotations;

namespace SewingMachineManagement.Application.Common.Options;

public record AppOptions
{
    public const string SectionName = "SewingMachineManagementAppOptions";
    [Required] public required string[] AllowedOriginsForCors { get; init; }
}
