using System.ComponentModel.DataAnnotations;

namespace SewingMachineManagement.Application.Common.Options;

public record ConnectionStringsOptions
{
    public const string SectionName = "ConnectionStrings";
    [Required] public required string SewingMachineManagementDb { get; init; }
}