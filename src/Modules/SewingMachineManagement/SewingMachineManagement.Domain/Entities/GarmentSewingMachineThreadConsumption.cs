using SewingMachineManagement.Domain.Interfaces;

namespace SewingMachineManagement.Domain.Entities;

public class GarmentSewingMachineThreadConsumption : IUpdateAudit, ICreateAudit
{
    public int Id { get; init; }
    public required short ConsumptionMeasurementOfUnitId { get; set; }
    public required short GarmentSewingMachineSpecificationId { get; set; }
    public required int LookupThreadTypeId { get; set; }
    public required byte ThreadCount { get; set; }
    public required decimal Consumption { get; set; }
    public decimal? PercentageConsumption { get; set; }
    public DateTime? LastUpdateDate { get; set; }
    public Guid? LastUpdatedBy { get; set; }
    public required DateTime CreationDate { get; set; }
    public required Guid CreatedBy { get; init; }
}