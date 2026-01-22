using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TrainingDatabaseInterface.Core.Entities;

#nullable disable

namespace TrainingDatabaseInterface.Data.Migrations;

[DbContext(typeof(TrainingDbContext))]
partial class TrainingDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.0")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.AuditLog", b =>
        {
            b.Property<Guid>("Id");

            b.Property<string>("Action")
                .IsRequired()
                .HasMaxLength(200);

            b.Property<string>("Detail")
                .HasMaxLength(2000);

            b.Property<string>("EntityId")
                .HasMaxLength(200);

            b.Property<string>("EntityName")
                .IsRequired()
                .HasMaxLength(200);

            b.Property<DateTime>("OccurredOn");

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.Property<Guid?>("UserId");

            b.HasKey("Id");

            b.HasIndex("UserId");

            b.ToTable("AuditLogs");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Course", b =>
        {
            b.Property<Guid>("Id");

            b.Property<int?>("CompetencyLengthMonths");

            b.Property<string>("Code")
                .IsRequired()
                .HasMaxLength(50);

            b.Property<Guid?>("DefaultTrainerEmployeeId");

            b.Property<string>("Description")
                .HasMaxLength(2000);

            b.Property<Guid?>("DomainCategoryId");

            b.Property<Guid?>("DomainSubcategoryId");

            b.Property<decimal?>("DurationHours")
                .HasColumnType("decimal(6,2)");

            b.Property<bool>("IsActive");

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.Property<string>("Title")
                .IsRequired()
                .HasMaxLength(200);

            b.Property<Guid?>("TrainingTypeId");

            b.Property<string>("VendorName")
                .HasMaxLength(200);

            b.Property<string>("VendorUrl")
                .HasMaxLength(400);

            b.HasKey("Id");

            b.HasIndex("Code")
                .IsUnique();

            b.HasIndex("DefaultTrainerEmployeeId");

            b.HasIndex("DomainCategoryId");

            b.HasIndex("DomainSubcategoryId");

            b.HasIndex("TrainingTypeId");

            b.ToTable("Courses");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Department", b =>
        {
            b.Property<Guid>("Id");

            b.Property<string>("Code")
                .HasMaxLength(20);

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(100);

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.HasKey("Id");

            b.HasIndex("Name")
                .IsUnique();

            b.ToTable("Departments");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Document", b =>
        {
            b.Property<Guid>("Id");

            b.Property<string>("ContentType")
                .HasMaxLength(200);

            b.Property<string>("FileName")
                .IsRequired()
                .HasMaxLength(260);

            b.Property<long?>("FileSizeBytes");

            b.Property<string>("Provider")
                .IsRequired()
                .HasMaxLength(100);

            b.Property<string>("ProviderKey")
                .IsRequired()
                .HasMaxLength(500);

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.Property<Guid>("TrainingRecordId");

            b.Property<DateTime>("UploadedOn");

            b.Property<Guid?>("UploadedByUserId");

            b.HasKey("Id");

            b.HasIndex("TrainingRecordId");

            b.HasIndex("UploadedByUserId");

            b.ToTable("Documents");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.DomainCategory", b =>
        {
            b.Property<Guid>("Id");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(100);

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.HasKey("Id");

            b.HasIndex("Name")
                .IsUnique();

            b.ToTable("DomainCategories");

            b.HasData(
                new
                {
                    Id = new Guid("51d5a72e-1e08-40d2-a8c7-0c4c1f26afc5"),
                    Name = "Safety"
                },
                new
                {
                    Id = new Guid("b38a7c3b-7a43-4c5d-af4d-42fae7723a15"),
                    Name = "Quality"
                });
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.DomainSubcategory", b =>
        {
            b.Property<Guid>("Id");

            b.Property<Guid>("DomainCategoryId");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(100);

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.HasKey("Id");

            b.HasIndex("DomainCategoryId", "Name")
                .IsUnique();

            b.ToTable("DomainSubcategories");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Employee", b =>
        {
            b.Property<Guid>("Id");

            b.Property<Guid>("DepartmentId");

            b.Property<string>("Email")
                .IsRequired()
                .HasMaxLength(200);

            b.Property<string>("EmployeeNumber")
                .IsRequired()
                .HasMaxLength(30);

            b.Property<string>("FirstName")
                .IsRequired()
                .HasMaxLength(100);

            b.Property<bool>("IsActive");

            b.Property<string>("LastName")
                .IsRequired()
                .HasMaxLength(100);

            b.Property<Guid?>("LineManagerEmployeeId");

            b.Property<Guid>("LocationId");

            b.Property<Guid>("PositionId");

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.HasKey("Id");

            b.HasIndex("DepartmentId");

            b.HasIndex("Email")
                .IsUnique();

            b.HasIndex("EmployeeNumber")
                .IsUnique();

            b.HasIndex("LineManagerEmployeeId");

            b.HasIndex("LocationId");

            b.HasIndex("PositionId");

            b.ToTable("Employees");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Location", b =>
        {
            b.Property<Guid>("Id");

            b.Property<string>("Code")
                .IsRequired()
                .HasMaxLength(20);

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(100);

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.HasKey("Id");

            b.HasIndex("Code")
                .IsUnique();

            b.ToTable("Locations");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Position", b =>
        {
            b.Property<Guid>("Id");

            b.Property<Guid>("DepartmentId");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(100);

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.HasKey("Id");

            b.HasIndex("DepartmentId", "Name")
                .IsUnique();

            b.ToTable("Positions");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Role", b =>
        {
            b.Property<Guid>("Id");

            b.Property<string>("Description");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(50);

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.HasKey("Id");

            b.HasIndex("Name")
                .IsUnique();

            b.ToTable("Roles");

            b.HasData(
                new
                {
                    Id = new Guid("6e9e05f2-0998-4d14-86c7-2d77c6cf52d0"),
                    Description = "System administrator",
                    Name = "Admin"
                },
                new
                {
                    Id = new Guid("a2f7cc77-2ec2-4e27-8ad1-6c5ae5d2e8c3"),
                    Description = "Training coordinator",
                    Name = "Trainer"
                },
                new
                {
                    Id = new Guid("63f1a2f4-9b4a-4b79-b6c6-2bb1d2ba9e6f"),
                    Description = "Line manager",
                    Name = "Manager"
                },
                new
                {
                    Id = new Guid("44b7dbb0-6191-4d44-b384-9091f8c5d132"),
                    Description = "Standard employee",
                    Name = "Employee"
                });
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.SkillMatrixRequirement", b =>
        {
            b.Property<Guid>("Id");

            b.Property<Guid>("CourseId");

            b.Property<Guid?>("LocationId");

            b.Property<Guid>("PositionId");

            b.Property<string>("RequirementCode")
                .HasMaxLength(1);

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.HasKey("Id");

            b.HasIndex("CourseId", "PositionId", "LocationId")
                .IsUnique();

            b.HasIndex("LocationId");

            b.HasIndex("PositionId");

            b.ToTable("SkillMatrixRequirements");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.TrainingRecord", b =>
        {
            b.Property<Guid>("Id");

            b.Property<DateTime>("CompletedOn");

            b.Property<Guid?>("ConfirmedByUserId");

            b.Property<Guid>("CourseId");

            b.Property<string>("EvidenceNote")
                .HasMaxLength(2000);

            b.Property<Guid>("EmployeeId");

            b.Property<DateTime?>("ExpiresOn");

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.HasKey("Id");

            b.HasIndex("ConfirmedByUserId");

            b.HasIndex("CourseId");

            b.HasIndex("EmployeeId");

            b.ToTable("TrainingRecords");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.TrainingType", b =>
        {
            b.Property<Guid>("Id");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(100);

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.HasKey("Id");

            b.HasIndex("Name")
                .IsUnique();

            b.ToTable("TrainingTypes");

            b.HasData(
                new
                {
                    Id = new Guid("60b2b4c2-55a6-4b9a-9e1e-6b3a27ac2412"),
                    Name = "In-person"
                },
                new
                {
                    Id = new Guid("7a785c7b-6e6f-4d39-8a2f-6b6a7437c9d1"),
                    Name = "Online"
                },
                new
                {
                    Id = new Guid("e7e1df36-0e07-4d47-9d9a-07f3e0da4c1d"),
                    Name = "Virtual ILT"
                },
                new
                {
                    Id = new Guid("da9d26f5-5e2c-4bc5-9a12-5a822120bc5e"),
                    Name = "Blended"
                },
                new
                {
                    Id = new Guid("5f51e7c0-4b61-4e18-9f5c-821ce1e2eabb"),
                    Name = "External Vendor"
                });
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.User", b =>
        {
            b.Property<Guid>("Id");

            b.Property<Guid?>("EmployeeId");

            b.Property<bool>("IsActive");

            b.Property<byte[]>("PasswordHash")
                .IsRequired();

            b.Property<byte[]>("PasswordSalt")
                .IsRequired();

            b.Property<Guid>("RoleId");

            b.Property<byte[]>("RowVersion")
                .IsRowVersion()
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();

            b.Property<string>("Username")
                .IsRequired()
                .HasMaxLength(50);

            b.HasKey("Id");

            b.HasIndex("EmployeeId");

            b.HasIndex("RoleId");

            b.HasIndex("Username")
                .IsUnique();

            b.ToTable("Users");

            b.HasData(
                new
                {
                    Id = new Guid("0c5f3f23-4a5b-4a37-a1e6-3ab6467f2dd3"),
                    EmployeeId = (Guid?)null,
                    IsActive = true,
                    PasswordHash = new byte[] { 168, 86, 217, 34, 242, 90, 22, 148, 56, 191, 83, 195, 114, 92, 79, 244, 30, 125, 200, 1, 21, 207, 188, 139, 188, 18, 29, 202, 163, 206, 209, 254 },
                    PasswordSalt = new byte[] { 107, 57, 129, 125, 51, 210, 31, 196, 246, 161, 82, 153, 1, 141, 206, 170 },
                    RoleId = new Guid("6e9e05f2-0998-4d14-86c7-2d77c6cf52d0"),
                    Username = "admin"
                });
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.AuditLog", b =>
        {
            b.HasOne("TrainingDatabaseInterface.Core.Entities.User", "User")
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.SetNull);

            b.Navigation("User");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Course", b =>
        {
            b.HasOne("TrainingDatabaseInterface.Core.Entities.Employee", "DefaultTrainerEmployee")
                .WithMany()
                .HasForeignKey("DefaultTrainerEmployeeId")
                .OnDelete(DeleteBehavior.SetNull);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.DomainCategory", "DomainCategory")
                .WithMany("Courses")
                .HasForeignKey("DomainCategoryId")
                .OnDelete(DeleteBehavior.SetNull);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.DomainSubcategory", "DomainSubcategory")
                .WithMany("Courses")
                .HasForeignKey("DomainSubcategoryId")
                .OnDelete(DeleteBehavior.SetNull);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.TrainingType", "TrainingType")
                .WithMany("Courses")
                .HasForeignKey("TrainingTypeId")
                .OnDelete(DeleteBehavior.SetNull);

            b.Navigation("DefaultTrainerEmployee");
            b.Navigation("DomainCategory");
            b.Navigation("DomainSubcategory");
            b.Navigation("TrainingType");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Document", b =>
        {
            b.HasOne("TrainingDatabaseInterface.Core.Entities.TrainingRecord", "TrainingRecord")
                .WithMany("Documents")
                .HasForeignKey("TrainingRecordId")
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.User", "UploadedByUser")
                .WithMany()
                .HasForeignKey("UploadedByUserId")
                .OnDelete(DeleteBehavior.SetNull);

            b.Navigation("TrainingRecord");
            b.Navigation("UploadedByUser");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.DomainSubcategory", b =>
        {
            b.HasOne("TrainingDatabaseInterface.Core.Entities.DomainCategory", "DomainCategory")
                .WithMany("Subcategories")
                .HasForeignKey("DomainCategoryId")
                .OnDelete(DeleteBehavior.Restrict);

            b.Navigation("DomainCategory");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Employee", b =>
        {
            b.HasOne("TrainingDatabaseInterface.Core.Entities.Department", "Department")
                .WithMany("Employees")
                .HasForeignKey("DepartmentId")
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.Employee", "LineManager")
                .WithMany("DirectReports")
                .HasForeignKey("LineManagerEmployeeId")
                .OnDelete(DeleteBehavior.SetNull);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.Location", "Location")
                .WithMany("Employees")
                .HasForeignKey("LocationId")
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.Position", "Position")
                .WithMany("Employees")
                .HasForeignKey("PositionId")
                .OnDelete(DeleteBehavior.Restrict);

            b.Navigation("Department");
            b.Navigation("LineManager");
            b.Navigation("Location");
            b.Navigation("Position");
            b.Navigation("DirectReports");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.Position", b =>
        {
            b.HasOne("TrainingDatabaseInterface.Core.Entities.Department", "Department")
                .WithMany("Positions")
                .HasForeignKey("DepartmentId")
                .OnDelete(DeleteBehavior.Restrict);

            b.Navigation("Department");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.SkillMatrixRequirement", b =>
        {
            b.HasOne("TrainingDatabaseInterface.Core.Entities.Course", "Course")
                .WithMany("SkillMatrixRequirements")
                .HasForeignKey("CourseId")
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.Location", "Location")
                .WithMany("SkillMatrixRequirements")
                .HasForeignKey("LocationId")
                .OnDelete(DeleteBehavior.SetNull);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.Position", "Position")
                .WithMany("SkillMatrixRequirements")
                .HasForeignKey("PositionId")
                .OnDelete(DeleteBehavior.Cascade);

            b.Navigation("Course");
            b.Navigation("Location");
            b.Navigation("Position");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.TrainingRecord", b =>
        {
            b.HasOne("TrainingDatabaseInterface.Core.Entities.User", "ConfirmedByUser")
                .WithMany()
                .HasForeignKey("ConfirmedByUserId")
                .OnDelete(DeleteBehavior.SetNull);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.Course", "Course")
                .WithMany("TrainingRecords")
                .HasForeignKey("CourseId")
                .OnDelete(DeleteBehavior.Restrict);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.Employee", "Employee")
                .WithMany("TrainingRecords")
                .HasForeignKey("EmployeeId")
                .OnDelete(DeleteBehavior.Restrict);

            b.Navigation("ConfirmedByUser");
            b.Navigation("Course");
            b.Navigation("Employee");
        });

        modelBuilder.Entity("TrainingDatabaseInterface.Core.Entities.User", b =>
        {
            b.HasOne("TrainingDatabaseInterface.Core.Entities.Employee", "Employee")
                .WithMany("Users")
                .HasForeignKey("EmployeeId")
                .OnDelete(DeleteBehavior.SetNull);

            b.HasOne("TrainingDatabaseInterface.Core.Entities.Role", "Role")
                .WithMany("Users")
                .HasForeignKey("RoleId")
                .OnDelete(DeleteBehavior.Restrict);

            b.Navigation("Employee");
            b.Navigation("Role");
        });
    }
}
