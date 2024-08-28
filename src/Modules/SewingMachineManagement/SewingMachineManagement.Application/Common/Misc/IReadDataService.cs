using SewingMachineManagement.Domain.DataTransferObjects.Response;

namespace SewingMachineManagement.Application.Common.Misc;

public interface IReadDataService<TResponse, in TKey, in TQueryDto>
{
    Task<TResponse?> ReadAsync(TKey id, CancellationToken ct = default);
    Task<PagedData<TResponse>> ReadAllAsync(TQueryDto dto);
}
