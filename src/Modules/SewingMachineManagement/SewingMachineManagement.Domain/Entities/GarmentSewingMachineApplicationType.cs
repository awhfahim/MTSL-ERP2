using SewingMachineManagement.Domain.Interfaces;

namespace SewingMachineManagement.Domain.Entities;

public class GarmentSewingMachineApplicationType : IAudit
{
    public short Id { get; init; }
    public required string Code { get; set; }
    public required string EnglishName { get; set; }
    public string? BengaliName { get; set; }
    public required string ShortName { get; set; }
    public required short DisplayOrder { get; set; }
    public required DateTime CreationDate { get; set; }
    public required Guid CreatedBy { get; init; }
    public DateTime? LastUpdateDate { get; set; }
    public Guid? LastUpdatedBy { get; set; }
    public required bool IsActive { get; set; }
}