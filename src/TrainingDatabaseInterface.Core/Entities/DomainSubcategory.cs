using System;
using System.Collections.Generic;

namespace TrainingDatabaseInterface.Core.Entities;

public class DomainSubcategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public Guid DomainCategoryId { get; set; }

    public DomainCategory? DomainCategory { get; set; }

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
