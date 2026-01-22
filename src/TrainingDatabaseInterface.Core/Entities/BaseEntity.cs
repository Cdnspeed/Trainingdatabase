using System;

namespace TrainingDatabaseInterface.Core.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public byte[] RowVersion { get; set; } = Array.Empty<byte>();
}
