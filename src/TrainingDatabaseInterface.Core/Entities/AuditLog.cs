using System;

namespace TrainingDatabaseInterface.Core.Entities;

public class AuditLog : BaseEntity
{
    public DateTime OccurredOn { get; set; }

    public Guid? UserId { get; set; }

    public User? User { get; set; }

    public string Action { get; set; } = string.Empty;

    public string EntityName { get; set; } = string.Empty;

    public string? EntityId { get; set; }

    public string? Detail { get; set; }
}
