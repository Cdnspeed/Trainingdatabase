using System;
using System.Collections.Generic;

namespace TrainingDatabaseInterface.Core.Entities;

public class TrainingRecord : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public Employee? Employee { get; set; }

    public Guid CourseId { get; set; }

    public Course? Course { get; set; }

    public DateTime CompletedOn { get; set; }

    public DateTime? ExpiresOn { get; set; }

    public Guid? ConfirmedByUserId { get; set; }

    public User? ConfirmedByUser { get; set; }

    public string? EvidenceNote { get; set; }

    public ICollection<Document> Documents { get; set; } = new List<Document>();
}
