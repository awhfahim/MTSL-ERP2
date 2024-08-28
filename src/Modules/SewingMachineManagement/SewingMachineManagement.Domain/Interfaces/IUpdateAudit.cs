namespace SewingMachineManagement.Domain.Interfaces;

public interface IUpdateAudit
{
    public DateTime? LastUpdateDate { get; set; }
    public Guid? LastUpdatedBy { get; set; }
}