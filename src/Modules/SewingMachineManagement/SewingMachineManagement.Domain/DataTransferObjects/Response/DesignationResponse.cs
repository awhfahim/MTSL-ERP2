namespace SewingMachineManagement.Domain.DataTransferObjects.Response;

public record DesignationResponse
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required DateTime CreatedAtUtc { get; init; }
    public required DateTime? UpdatedAtUtc { get; init; }
    public required Guid DepartmentId { get; init; }
    public required string DepartmentTitle { get; init; }
    public required Guid GradeId { get; init; }
    public required string GradeLevel { get; init; }
}
