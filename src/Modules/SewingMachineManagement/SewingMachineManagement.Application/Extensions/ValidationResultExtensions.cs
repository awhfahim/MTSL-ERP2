using FluentValidation.Results;

namespace SewingMachineManagement.Application.Extensions;

public static class ValidationResultExtensions
{
    public static List<string> GetErrorMessages(this ValidationResult result) =>
        result.Errors.Select(x => x.ErrorMessage).ToList();

    public static string GetErrorMessage(this ValidationResult result) =>
        result.Errors.Select(x => x.ErrorMessage).Aggregate((x, y) => $"{x}, {y}");
}
