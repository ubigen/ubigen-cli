namespace Ubigen.Core.Models;

public record Event
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}