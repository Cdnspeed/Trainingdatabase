using System;

namespace TrainingDatabaseInterface.Core.Entities;

public class SkillMatrixRequirement : BaseEntity
{
    public Guid CourseId { get; set; }

    public Course? Course { get; set; }

    public Guid PositionId { get; set; }

    public Position? Position { get; set; }

    public Guid? LocationId { get; set; }

    public Location? Location { get; set; }

    public string? RequirementCode { get; set; }
}
