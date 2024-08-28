using SewingMachineManagement.Domain.Interfaces;

namespace SewingMachineManagement.Domain.Entities;

public class GarmentSewingMachineGuide : ICreateAudit, IUpdateAudit
{
    public int Id { get; init; }
    public required short GarmentSewingMachineSpecificationId { get; set; }
    public required string Description { get; set; }
    public required short GarmentSewingMachineGuideTypeId { get; set; }
    public required DateTime CreationDate { get; set; }
    public required Guid CreatedBy { get; init; }
    public DateTime? LastUpdateDate { get; set; }
    public Guid? LastUpdatedBy { get; set; }
}