namespace SewingMachineManagement.Domain.Interfaces;

public interface IAudit : ICreateAudit, IUpdateAudit, IStatusAudit
{
}