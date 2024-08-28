namespace SewingMachineManagement.Application.Providers;

public interface IGuidProvider
{
    Guid SortableGuid();
    Guid RandomGuid();
}
