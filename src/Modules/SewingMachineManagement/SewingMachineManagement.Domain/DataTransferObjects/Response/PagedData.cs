namespace SewingMachineManagement.Domain.DataTransferObjects.Response;

public record PagedData<T>(ICollection<T> Payload, long TotalCount);
