using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SewingMachineManagement.Domain.DataTransferObjects.Request;

public class TabulatorQueryDto
{
    [Required] [JsonPropertyName("size")] public int Size { get; set; }
    [Required] [JsonPropertyName("page")] public int Page { get; set; } = 1;
    [JsonPropertyName("filter")] public IReadOnlyList<TabulatorFilterDto> Filters { get; init; } = [];
    [JsonPropertyName("sort")] public IReadOnlyList<TabulatorSortingDto> Sorters { get; init; } = [];
}
