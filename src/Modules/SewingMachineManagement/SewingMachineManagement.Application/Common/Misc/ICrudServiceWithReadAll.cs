using SewingMachineManagement.Domain.DataTransferObjects.Response;

namespace SewingMachineManagement.Application.Common.Misc;

public interface ICrudServiceWithReadAll<TEntity, in TKey, in TCreateOrUpdateDto, in TQueryDto,
    TFailedOutcome> : ICrudService<TEntity, TKey, TCreateOrUpdateDto, TFailedOutcome>
    where TEntity : notnull
    where TFailedOutcome : notnull
{
    Task<PagedData<TEntity>> ReadAllAsync(TQueryDto dto);
}
