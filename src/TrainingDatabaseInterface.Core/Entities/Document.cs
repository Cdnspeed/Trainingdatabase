using System;

namespace TrainingDatabaseInterface.Core.Entities;

public class Document : BaseEntity
{
    public Guid TrainingRecordId { get; set; }

    public TrainingRecord? TrainingRecord { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string Provider { get; set; } = string.Empty;

    public string ProviderKey { get; set; } = string.Empty;

    public string? ContentType { get; set; }

    public long? FileSizeBytes { get; set; }

    public DateTime UploadedOn { get; set; }

    public Guid? UploadedByUserId { get; set; }

    public User? UploadedByUser { get; set; }
}
