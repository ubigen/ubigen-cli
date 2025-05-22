namespace Ubigen.Core.Models;

public record BoundedContext
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;

    public IList<Entity>  Entities { get; init; } = new List<Entity>();
    public IList<Command> Commands { get; init; } = new List<Command>();
    public IList<Event> Events { get; init; } = new List<Event>();
}