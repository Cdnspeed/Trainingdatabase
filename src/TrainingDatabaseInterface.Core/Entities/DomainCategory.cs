using System.Collections.Generic;

namespace TrainingDatabaseInterface.Core.Entities;

public class DomainCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<DomainSubcategory> Subcategories { get; set; } = new List<DomainSubcategory>();

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
