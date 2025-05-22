namespace Ubigen.Core.Models;

public record Entity
{
    public string Name        { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    public IList<Property> Properties { get; init; } = new List<Property>();
}

public record Property
{
    public string Name { get; init; } = string.Empty;
    public string Type { get; init; } = "string";
    public string Description { get; init; } = string.Empty;

    public IDictionary<string, object> Metadata { get; init; } = new Dictionary<string, object>();
}