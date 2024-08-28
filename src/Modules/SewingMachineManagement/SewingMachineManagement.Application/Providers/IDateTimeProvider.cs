namespace SewingMachineManagement.Application.Providers;

public interface IDateTimeProvider
{
    DateTime CurrentUtcDateTime { get; }
    DateTime CurrentLocalDateTime { get; }
    DateOnly CurrentUtcDate { get; }
    TimeOnly CurrentUtcTime { get; }
    DateOnly CurrentLocalDate { get; }
    TimeOnly CurrentLocalTime { get; }
}