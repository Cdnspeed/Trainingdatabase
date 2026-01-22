using System.Collections.Generic;

namespace TrainingDatabaseInterface.Core.Entities;

public class Location : BaseEntity
{
    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public ICollection<SkillMatrixRequirement> SkillMatrixRequirements { get; set; } = new List<SkillMatrixRequirement>();
}
