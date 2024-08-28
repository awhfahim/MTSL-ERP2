namespace SewingMachineManagement.Domain.Interfaces;

public interface ITimestamp
{
    public DateTime CreatedAtUtc { get; set; }
    public DateTime UpdatedAtUtc { get; set; }
}
