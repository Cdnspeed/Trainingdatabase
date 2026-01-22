using Microsoft.EntityFrameworkCore;
using TrainingDatabaseInterface.Core.Entities;
using TrainingDatabaseInterface.Core.Security;

namespace TrainingDatabaseInterface.Data;

public class TrainingDbContext : DbContext
{
    public TrainingDbContext(DbContextOptions<TrainingDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<DomainCategory> DomainCategories => Set<DomainCategory>();
    public DbSet<DomainSubcategory> DomainSubcategories => Set<DomainSubcategory>();
    public DbSet<TrainingType> TrainingTypes => Set<TrainingType>();
    public DbSet<SkillMatrixRequirement> SkillMatrixRequirements => Set<SkillMatrixRequirement>();
    public DbSet<TrainingRecord> TrainingRecords => Set<TrainingRecord>();
    public DbSet<Document> Documents => Set<Document>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.RowVersion).IsRowVersion();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Username).HasMaxLength(50).IsRequired();
            entity.HasIndex(e => e.Username).IsUnique();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.PasswordSalt).IsRequired();
            entity.Property(e => e.RowVersion).IsRowVersion();
            entity.HasOne(e => e.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Employee)
                .WithMany(emp => emp.Users)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(20).IsRequired();
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.RowVersion).IsRowVersion();
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.RowVersion).IsRowVersion();
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.HasIndex(e => new { e.DepartmentId, e.Name }).IsUnique();
            entity.Property(e => e.RowVersion).IsRowVersion();
            entity.HasOne(e => e.Department)
                .WithMany(d => d.Positions)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeNumber).HasMaxLength(30).IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(200).IsRequired();
            entity.HasIndex(e => e.EmployeeNumber).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.Property(e => e.RowVersion).IsRowVersion();
            entity.HasOne(e => e.Location)
                .WithMany(l => l.Employees)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.LineManager)
                .WithMany(m => m.DirectReports)
                .HasForeignKey(e => e.LineManagerEmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<DomainCategory>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.RowVersion).IsRowVersion();
        });

        modelBuilder.Entity<DomainSubcategory>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.HasIndex(e => new { e.DomainCategoryId, e.Name }).IsUnique();
            entity.Property(e => e.RowVersion).IsRowVersion();
            entity.HasOne(e => e.DomainCategory)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(e => e.DomainCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TrainingType>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();
            entity.Property(e => e.RowVersion).IsRowVersion();
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Title).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.VendorName).HasMaxLength(200);
            entity.Property(e => e.VendorUrl).HasMaxLength(400);
            entity.Property(e => e.DurationHours).HasColumnType("decimal(6,2)");
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.RowVersion).IsRowVersion();
            entity.HasOne(e => e.DomainCategory)
                .WithMany(dc => dc.Courses)
                .HasForeignKey(e => e.DomainCategoryId)
                .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.DomainSubcategory)
                .WithMany(ds => ds.Courses)
                .HasForeignKey(e => e.DomainSubcategoryId)
                .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.TrainingType)
                .WithMany(tt => tt.Courses)
                .HasForeignKey(e => e.TrainingTypeId)
                .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.DefaultTrainerEmployee)
                .WithMany()
                .HasForeignKey(e => e.DefaultTrainerEmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<SkillMatrixRequirement>(entity =>
        {
            entity.Property(e => e.RequirementCode).HasMaxLength(1);
            entity.HasIndex(e => new { e.CourseId, e.PositionId, e.LocationId }).IsUnique();
            entity.Property(e => e.RowVersion).IsRowVersion();
            entity.HasOne(e => e.Course)
                .WithMany(c => c.SkillMatrixRequirements)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Position)
                .WithMany(p => p.SkillMatrixRequirements)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Location)
                .WithMany(l => l.SkillMatrixRequirements)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<TrainingRecord>(entity =>
        {
            entity.Property(e => e.EvidenceNote).HasMaxLength(2000);
            entity.Property(e => e.RowVersion).IsRowVersion();
            entity.HasOne(e => e.Employee)
                .WithMany(emp => emp.TrainingRecords)
                .HasForeignKey(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Course)
                .WithMany(c => c.TrainingRecords)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.ConfirmedByUser)
                .WithMany()
                .HasForeignKey(e => e.ConfirmedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.Property(e => e.FileName).HasMaxLength(260).IsRequired();
            entity.Property(e => e.Provider).HasMaxLength(100).IsRequired();
            entity.Property(e => e.ProviderKey).HasMaxLength(500).IsRequired();
            entity.Property(e => e.ContentType).HasMaxLength(200);
            entity.Property(e => e.RowVersion).IsRowVersion();
            entity.HasOne(e => e.TrainingRecord)
                .WithMany(tr => tr.Documents)
                .HasForeignKey(e => e.TrainingRecordId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.UploadedByUser)
                .WithMany()
                .HasForeignKey(e => e.UploadedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.Property(e => e.Action).HasMaxLength(200).IsRequired();
            entity.Property(e => e.EntityName).HasMaxLength(200).IsRequired();
            entity.Property(e => e.EntityId).HasMaxLength(200);
            entity.Property(e => e.Detail).HasMaxLength(2000);
            entity.Property(e => e.RowVersion).IsRowVersion();
            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        var adminRoleId = SeedIds.RoleAdminId;
        var trainerRoleId = SeedIds.RoleTrainerId;
        var managerRoleId = SeedIds.RoleManagerId;
        var employeeRoleId = SeedIds.RoleEmployeeId;

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = adminRoleId, Name = "Admin", Description = "System administrator" },
            new Role { Id = trainerRoleId, Name = "Trainer", Description = "Training coordinator" },
            new Role { Id = managerRoleId, Name = "Manager", Description = "Line manager" },
            new Role { Id = employeeRoleId, Name = "Employee", Description = "Standard employee" }
        );

        var adminSalt = SeedIds.AdminPasswordSalt;
        var adminHash = PasswordHasher.CreateHash(SeedIds.AdminPassword, adminSalt);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = SeedIds.AdminUserId,
                Username = "admin",
                PasswordHash = adminHash,
                PasswordSalt = adminSalt,
                RoleId = adminRoleId,
                IsActive = true
            }
        );

        modelBuilder.Entity<TrainingType>().HasData(
            new TrainingType { Id = SeedIds.TrainingTypeInPersonId, Name = "In-person" },
            new TrainingType { Id = SeedIds.TrainingTypeOnlineId, Name = "Online" },
            new TrainingType { Id = SeedIds.TrainingTypeVirtualIltId, Name = "Virtual ILT" },
            new TrainingType { Id = SeedIds.TrainingTypeBlendedId, Name = "Blended" },
            new TrainingType { Id = SeedIds.TrainingTypeExternalVendorId, Name = "External Vendor" }
        );

        modelBuilder.Entity<DomainCategory>().HasData(
            new DomainCategory { Id = SeedIds.DomainCategorySafetyId, Name = "Safety" },
            new DomainCategory { Id = SeedIds.DomainCategoryQualityId, Name = "Quality" }
        );
    }
}
