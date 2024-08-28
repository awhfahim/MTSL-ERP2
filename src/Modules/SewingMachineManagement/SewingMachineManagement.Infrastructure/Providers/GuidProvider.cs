using SewingMachineManagement.Application.Providers;

namespace SewingMachineManagement.Infrastructure.Providers;

public class GuidProvider : IGuidProvider
{
    public Guid SortableGuid() => Ulid.NewUlid().ToGuid();

    public Guid RandomGuid() => Guid.NewGuid();
}
