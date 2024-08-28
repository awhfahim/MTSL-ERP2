using SewingMachineManagement.Application.Providers;

namespace SewingMachineManagement.Infrastructure.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime CurrentUtcDateTime => TimeProvider.System.GetUtcNow().UtcDateTime;
    public DateTime CurrentLocalDateTime => TimeProvider.System.GetLocalNow().LocalDateTime;
    public DateOnly CurrentUtcDate => DateOnly.FromDateTime(CurrentUtcDateTime);
    public TimeOnly CurrentUtcTime => TimeOnly.FromDateTime(CurrentUtcDateTime);
    public DateOnly CurrentLocalDate => DateOnly.FromDateTime(CurrentLocalDateTime);
    public TimeOnly CurrentLocalTime => TimeOnly.FromDateTime(CurrentLocalDateTime);
}