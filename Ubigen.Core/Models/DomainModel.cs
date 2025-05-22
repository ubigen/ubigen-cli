namespace Ubigen.Core.Models;


public record DomainModel
{
    public string ServiceName { get; init; } = string.Empty;
    public string Version { get; init; } = "1.0.0";

    public IList<BoundedContext> BoundedContexts { get; init; } = new List<BoundedContext>();
    public IList<Integration> Integrations { get; init; } = new List<Integration>();
}