using SewingMachineManagement.Domain.Interfaces;

namespace SewingMachineManagement.Domain.Entities;

public class LookupData : IAudit, IVersioning
{
    public int Id { get; init; }
    public required int LookupTableId { get; set; }
    public string? Code { get; set; }
    public required string EnglishName { get; set; }
    public string? BengaliName { get; set; }
    public required string ShortName { get; set; }
    public string? Description { get; set; }
    public string? DataPrefix { get; set; }
    public string? ColorCode { get; set; }
    public int DisplayOrder { get; set; }
    public decimal? ParameterValue { get; set; }
    public required DateTime CreationDate { get; set; }
    public required Guid CreatedBy { get; init; }
    public DateTime? LastUpdateDate { get; set; }
    public Guid? LastUpdatedBy { get; set; }
    public required bool IsActive { get; set; }
    public required short VersionNumber { get; set; } = 1;
}