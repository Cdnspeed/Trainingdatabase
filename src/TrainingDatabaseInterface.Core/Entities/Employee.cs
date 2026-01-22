using System;
using System.Collections.Generic;

namespace TrainingDatabaseInterface.Core.Entities;

public class Employee : BaseEntity
{
    public string EmployeeNumber { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public Guid LocationId { get; set; }

    public Location? Location { get; set; }

    public Guid DepartmentId { get; set; }

    public Department? Department { get; set; }

    public Guid PositionId { get; set; }

    public Position? Position { get; set; }

    public Guid? LineManagerEmployeeId { get; set; }

    public Employee? LineManager { get; set; }

    public ICollection<Employee> DirectReports { get; set; } = new List<Employee>();

    public ICollection<TrainingRecord> TrainingRecords { get; set; } = new List<TrainingRecord>();

    public ICollection<User> Users { get; set; } = new List<User>();
}
