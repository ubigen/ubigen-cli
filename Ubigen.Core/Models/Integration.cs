namespace Ubigen.Core.Models;

public record Integration
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}