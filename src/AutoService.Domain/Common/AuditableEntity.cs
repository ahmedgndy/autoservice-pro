using AutoService.Domain.Constants;

namespace AutoService.Domain.Common;

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset CreatedAt { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTimeOffset? LastModifiedAt { get; private set; }
    public string? ModifiedBy { get; private set; }

    protected AuditableEntity() : base()
    {
        CreatedAt = DateTimeOffset.UtcNow;
        CreatedBy = AutoServiceConstants.SystemUser;
    }

    protected AuditableEntity(Guid id, string createdBy) : base(id)
    {
        CreatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
    }

    public void SetModified(string modifiedBy)
    {
        LastModifiedAt = DateTimeOffset.UtcNow;
        ModifiedBy = modifiedBy;
    }
}