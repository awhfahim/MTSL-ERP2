using System.Data.Common;

namespace SewingMachineManagement.Domain.Interfaces;
public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    void Save();
    Task SaveAsync();
    Task<DbTransaction> BeginTransactionAsync();
}
