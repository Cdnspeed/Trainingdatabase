using System.Collections.Generic;

namespace TrainingDatabaseInterface.Core.Entities;

public class TrainingType : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
