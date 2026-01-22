using System;
using System.Collections.Generic;

namespace TrainingDatabaseInterface.Core.Entities;

public class Position : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public Guid DepartmentId { get; set; }

    public Department? Department { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public ICollection<SkillMatrixRequirement> SkillMatrixRequirements { get; set; } = new List<SkillMatrixRequirement>();
}
