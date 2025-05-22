namespace Ubigen.Core.Models;

public record Command
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    public IList<Parameter> Parameters { get; init; } = new List<Parameter>();
}

public record Parameter
{
    public string Name { get; init; } = string.Empty;
    public string Type { get; init; } = "string";
    public string Description { get; init; } = string.Empty;
}