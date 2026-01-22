using System;
using System.Collections.Generic;

namespace TrainingDatabaseInterface.Core.Entities;

public class Course : BaseEntity
{
    public string Code { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Guid? DomainCategoryId { get; set; }

    public DomainCategory? DomainCategory { get; set; }

    public Guid? DomainSubcategoryId { get; set; }

    public DomainSubcategory? DomainSubcategory { get; set; }

    public Guid? TrainingTypeId { get; set; }

    public TrainingType? TrainingType { get; set; }

    public string? VendorName { get; set; }

    public string? VendorUrl { get; set; }

    public int? CompetencyLengthMonths { get; set; }

    public decimal? DurationHours { get; set; }

    public Guid? DefaultTrainerEmployeeId { get; set; }

    public Employee? DefaultTrainerEmployee { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<TrainingRecord> TrainingRecords { get; set; } = new List<TrainingRecord>();

    public ICollection<SkillMatrixRequirement> SkillMatrixRequirements { get; set; } = new List<SkillMatrixRequirement>();
}
