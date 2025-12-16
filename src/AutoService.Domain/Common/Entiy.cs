namespace AutoService.Domain.Common;
/// <summary>
/// Represents a base entity with an identifier.
/// </summary>

public abstract class Entity
{
    public Guid Id { get; }
    protected Entity() { }
    protected Entity(Guid id)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
    }
}