using System;

namespace TrainingDatabaseInterface.Core.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;

    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();

    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();

    public bool IsActive { get; set; } = true;

    public Guid RoleId { get; set; }

    public Role? Role { get; set; }

    public Guid? EmployeeId { get; set; }

    public Employee? Employee { get; set; }
}
