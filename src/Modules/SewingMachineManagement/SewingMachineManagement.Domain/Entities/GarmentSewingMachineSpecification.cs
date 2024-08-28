using SewingMachineManagement.Domain.Interfaces;

namespace SewingMachineManagement.Domain.Entities;

public class GarmentSewingMachineSpecification : ICreateAudit, IUpdateAudit
{
    public short Id { get; init; }
    public required short GarmentSewingMachineTypeId { get; set; }
    public short? GarmentSewingMachineBedTypeId { get; set; }
    public required short GarmentStitchTypeId { get; set; }
    public required short GarmentSewingMachineApplicationTypeId { get; set; }
    public int? LookupThreadTrimTypeId { get; set; }
    public required byte NeedleCount { get; set; }
    public required byte ThreadCount { get; set; }
    public required int StandardRotationPerMinute { get; set; }
    public byte? StandardStitchPerInch { get; set; }
    public required string Description { get; set; }
    public required DateTime CreationDate { get; set; }
    public Guid CreatedBy { get; init; }
    public DateTime? LastUpdateDate { get; set; }
    public Guid? LastUpdatedBy { get; set; }
}