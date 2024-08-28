namespace SewingMachineManagement.Domain.Interfaces;

public interface ICreateAudit
{
    public DateTime CreationDate { get; set; }
    public Guid CreatedBy { get; init; }
}