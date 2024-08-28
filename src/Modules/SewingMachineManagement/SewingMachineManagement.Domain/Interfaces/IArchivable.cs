namespace SewingMachineManagement.Domain.Interfaces;

public interface IArchivable
{
    public bool IsArchived { get; set; }
    public DateTime? ArchivedAtUtc { get; set; }
}
