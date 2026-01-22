using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingDatabaseInterface.Data.Migrations;

public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Departments",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(maxLength: 100, nullable: false),
                Code = table.Column<string>(maxLength: 20, nullable: true),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Departments", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "DomainCategories",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(maxLength: 100, nullable: false),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DomainCategories", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Locations",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Code = table.Column<string>(maxLength: 20, nullable: false),
                Name = table.Column<string>(maxLength: 100, nullable: false),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Locations", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Roles",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(maxLength: 50, nullable: false),
                Description = table.Column<string>(nullable: true),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Roles", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "TrainingTypes",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(maxLength: 100, nullable: false),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TrainingTypes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "DomainSubcategories",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(maxLength: 100, nullable: false),
                DomainCategoryId = table.Column<Guid>(nullable: false),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DomainSubcategories", x => x.Id);
                table.ForeignKey(
                    name: "FK_DomainSubcategories_DomainCategories_DomainCategoryId",
                    column: x => x.DomainCategoryId,
                    principalTable: "DomainCategories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Positions",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Name = table.Column<string>(maxLength: 100, nullable: false),
                DepartmentId = table.Column<Guid>(nullable: false),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Positions", x => x.Id);
                table.ForeignKey(
                    name: "FK_Positions_Departments_DepartmentId",
                    column: x => x.DepartmentId,
                    principalTable: "Departments",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Employees",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                EmployeeNumber = table.Column<string>(maxLength: 30, nullable: false),
                FirstName = table.Column<string>(maxLength: 100, nullable: false),
                LastName = table.Column<string>(maxLength: 100, nullable: false),
                Email = table.Column<string>(maxLength: 200, nullable: false),
                IsActive = table.Column<bool>(nullable: false),
                LocationId = table.Column<Guid>(nullable: false),
                DepartmentId = table.Column<Guid>(nullable: false),
                PositionId = table.Column<Guid>(nullable: false),
                LineManagerEmployeeId = table.Column<Guid>(nullable: true),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
                table.ForeignKey(
                    name: "FK_Employees_Departments_DepartmentId",
                    column: x => x.DepartmentId,
                    principalTable: "Departments",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Employees_Employees_LineManagerEmployeeId",
                    column: x => x.LineManagerEmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
                table.ForeignKey(
                    name: "FK_Employees_Locations_LocationId",
                    column: x => x.LocationId,
                    principalTable: "Locations",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_Employees_Positions_PositionId",
                    column: x => x.PositionId,
                    principalTable: "Positions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "Courses",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Code = table.Column<string>(maxLength: 50, nullable: false),
                Title = table.Column<string>(maxLength: 200, nullable: false),
                Description = table.Column<string>(maxLength: 2000, nullable: true),
                DomainCategoryId = table.Column<Guid>(nullable: true),
                DomainSubcategoryId = table.Column<Guid>(nullable: true),
                TrainingTypeId = table.Column<Guid>(nullable: true),
                VendorName = table.Column<string>(maxLength: 200, nullable: true),
                VendorUrl = table.Column<string>(maxLength: 400, nullable: true),
                CompetencyLengthMonths = table.Column<int>(nullable: true),
                DurationHours = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                DefaultTrainerEmployeeId = table.Column<Guid>(nullable: true),
                IsActive = table.Column<bool>(nullable: false),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Courses", x => x.Id);
                table.ForeignKey(
                    name: "FK_Courses_DomainCategories_DomainCategoryId",
                    column: x => x.DomainCategoryId,
                    principalTable: "DomainCategories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
                table.ForeignKey(
                    name: "FK_Courses_DomainSubcategories_DomainSubcategoryId",
                    column: x => x.DomainSubcategoryId,
                    principalTable: "DomainSubcategories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
                table.ForeignKey(
                    name: "FK_Courses_Employees_DefaultTrainerEmployeeId",
                    column: x => x.DefaultTrainerEmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
                table.ForeignKey(
                    name: "FK_Courses_TrainingTypes_TrainingTypeId",
                    column: x => x.TrainingTypeId,
                    principalTable: "TrainingTypes",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                Username = table.Column<string>(maxLength: 50, nullable: false),
                PasswordHash = table.Column<byte[]>(nullable: false),
                PasswordSalt = table.Column<byte[]>(nullable: false),
                IsActive = table.Column<bool>(nullable: false),
                RoleId = table.Column<Guid>(nullable: false),
                EmployeeId = table.Column<Guid>(nullable: true),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
                table.ForeignKey(
                    name: "FK_Users_Employees_EmployeeId",
                    column: x => x.EmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
                table.ForeignKey(
                    name: "FK_Users_Roles_RoleId",
                    column: x => x.RoleId,
                    principalTable: "Roles",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            });

        migrationBuilder.CreateTable(
            name: "SkillMatrixRequirements",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                CourseId = table.Column<Guid>(nullable: false),
                PositionId = table.Column<Guid>(nullable: false),
                LocationId = table.Column<Guid>(nullable: true),
                RequirementCode = table.Column<string>(maxLength: 1, nullable: true),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SkillMatrixRequirements", x => x.Id);
                table.ForeignKey(
                    name: "FK_SkillMatrixRequirements_Courses_CourseId",
                    column: x => x.CourseId,
                    principalTable: "Courses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_SkillMatrixRequirements_Locations_LocationId",
                    column: x => x.LocationId,
                    principalTable: "Locations",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
                table.ForeignKey(
                    name: "FK_SkillMatrixRequirements_Positions_PositionId",
                    column: x => x.PositionId,
                    principalTable: "Positions",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "TrainingRecords",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                EmployeeId = table.Column<Guid>(nullable: false),
                CourseId = table.Column<Guid>(nullable: false),
                CompletedOn = table.Column<DateTime>(nullable: false),
                ExpiresOn = table.Column<DateTime>(nullable: true),
                ConfirmedByUserId = table.Column<Guid>(nullable: true),
                EvidenceNote = table.Column<string>(maxLength: 2000, nullable: true),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TrainingRecords", x => x.Id);
                table.ForeignKey(
                    name: "FK_TrainingRecords_Courses_CourseId",
                    column: x => x.CourseId,
                    principalTable: "Courses",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_TrainingRecords_Employees_EmployeeId",
                    column: x => x.EmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
                table.ForeignKey(
                    name: "FK_TrainingRecords_Users_ConfirmedByUserId",
                    column: x => x.ConfirmedByUserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
            });

        migrationBuilder.CreateTable(
            name: "AuditLogs",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                OccurredOn = table.Column<DateTime>(nullable: false),
                UserId = table.Column<Guid>(nullable: true),
                Action = table.Column<string>(maxLength: 200, nullable: false),
                EntityName = table.Column<string>(maxLength: 200, nullable: false),
                EntityId = table.Column<string>(maxLength: 200, nullable: true),
                Detail = table.Column<string>(maxLength: 2000, nullable: true),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AuditLogs", x => x.Id);
                table.ForeignKey(
                    name: "FK_AuditLogs_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
            });

        migrationBuilder.CreateTable(
            name: "Documents",
            columns: table => new
            {
                Id = table.Column<Guid>(nullable: false),
                TrainingRecordId = table.Column<Guid>(nullable: false),
                FileName = table.Column<string>(maxLength: 260, nullable: false),
                Provider = table.Column<string>(maxLength: 100, nullable: false),
                ProviderKey = table.Column<string>(maxLength: 500, nullable: false),
                ContentType = table.Column<string>(maxLength: 200, nullable: true),
                FileSizeBytes = table.Column<long>(nullable: true),
                UploadedOn = table.Column<DateTime>(nullable: false),
                UploadedByUserId = table.Column<Guid>(nullable: true),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Documents", x => x.Id);
                table.ForeignKey(
                    name: "FK_Documents_TrainingRecords_TrainingRecordId",
                    column: x => x.TrainingRecordId,
                    principalTable: "TrainingRecords",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Documents_Users_UploadedByUserId",
                    column: x => x.UploadedByUserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.SetNull);
            });

        migrationBuilder.InsertData(
            table: "DomainCategories",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { new Guid("51d5a72e-1e08-40d2-a8c7-0c4c1f26afc5"), "Safety" },
                { new Guid("b38a7c3b-7a43-4c5d-af4d-42fae7723a15"), "Quality" }
            });

        migrationBuilder.InsertData(
            table: "Roles",
            columns: new[] { "Id", "Description", "Name" },
            values: new object[,]
            {
                { new Guid("6e9e05f2-0998-4d14-86c7-2d77c6cf52d0"), "System administrator", "Admin" },
                { new Guid("a2f7cc77-2ec2-4e27-8ad1-6c5ae5d2e8c3"), "Training coordinator", "Trainer" },
                { new Guid("63f1a2f4-9b4a-4b79-b6c6-2bb1d2ba9e6f"), "Line manager", "Manager" },
                { new Guid("44b7dbb0-6191-4d44-b384-9091f8c5d132"), "Standard employee", "Employee" }
            });

        migrationBuilder.InsertData(
            table: "TrainingTypes",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { new Guid("60b2b4c2-55a6-4b9a-9e1e-6b3a27ac2412"), "In-person" },
                { new Guid("7a785c7b-6e6f-4d39-8a2f-6b6a7437c9d1"), "Online" },
                { new Guid("e7e1df36-0e07-4d47-9d9a-07f3e0da4c1d"), "Virtual ILT" },
                { new Guid("da9d26f5-5e2c-4bc5-9a12-5a822120bc5e"), "Blended" },
                { new Guid("5f51e7c0-4b61-4e18-9f5c-821ce1e2eabb"), "External Vendor" }
            });

        migrationBuilder.InsertData(
            table: "Users",
            columns: new[] { "Id", "EmployeeId", "IsActive", "PasswordHash", "PasswordSalt", "RoleId", "Username" },
            values: new object[]
            {
                new Guid("0c5f3f23-4a5b-4a37-a1e6-3ab6467f2dd3"),
                null,
                true,
                new byte[] { 168, 86, 217, 34, 242, 90, 22, 148, 56, 191, 83, 195, 114, 92, 79, 244, 30, 125, 200, 1, 21, 207, 188, 139, 188, 18, 29, 202, 163, 206, 209, 254 },
                new byte[] { 107, 57, 129, 125, 51, 210, 31, 196, 246, 161, 82, 153, 1, 141, 206, 170 },
                new Guid("6e9e05f2-0998-4d14-86c7-2d77c6cf52d0"),
                "admin"
            });

        migrationBuilder.CreateIndex(
            name: "IX_AuditLogs_UserId",
            table: "AuditLogs",
            column: "UserId");

        migrationBuilder.CreateIndex(
            name: "IX_Courses_Code",
            table: "Courses",
            column: "Code",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Courses_DefaultTrainerEmployeeId",
            table: "Courses",
            column: "DefaultTrainerEmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_Courses_DomainCategoryId",
            table: "Courses",
            column: "DomainCategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Courses_DomainSubcategoryId",
            table: "Courses",
            column: "DomainSubcategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Courses_TrainingTypeId",
            table: "Courses",
            column: "TrainingTypeId");

        migrationBuilder.CreateIndex(
            name: "IX_Departments_Name",
            table: "Departments",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Documents_TrainingRecordId",
            table: "Documents",
            column: "TrainingRecordId");

        migrationBuilder.CreateIndex(
            name: "IX_Documents_UploadedByUserId",
            table: "Documents",
            column: "UploadedByUserId");

        migrationBuilder.CreateIndex(
            name: "IX_DomainCategories_Name",
            table: "DomainCategories",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_DomainSubcategories_DomainCategoryId_Name",
            table: "DomainSubcategories",
            columns: new[] { "DomainCategoryId", "Name" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Employees_DepartmentId",
            table: "Employees",
            column: "DepartmentId");

        migrationBuilder.CreateIndex(
            name: "IX_Employees_Email",
            table: "Employees",
            column: "Email",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Employees_EmployeeNumber",
            table: "Employees",
            column: "EmployeeNumber",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Employees_LineManagerEmployeeId",
            table: "Employees",
            column: "LineManagerEmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_Employees_LocationId",
            table: "Employees",
            column: "LocationId");

        migrationBuilder.CreateIndex(
            name: "IX_Employees_PositionId",
            table: "Employees",
            column: "PositionId");

        migrationBuilder.CreateIndex(
            name: "IX_Locations_Code",
            table: "Locations",
            column: "Code",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Positions_DepartmentId_Name",
            table: "Positions",
            columns: new[] { "DepartmentId", "Name" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Roles_Name",
            table: "Roles",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_SkillMatrixRequirements_CourseId_PositionId_LocationId",
            table: "SkillMatrixRequirements",
            columns: new[] { "CourseId", "PositionId", "LocationId" },
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_SkillMatrixRequirements_LocationId",
            table: "SkillMatrixRequirements",
            column: "LocationId");

        migrationBuilder.CreateIndex(
            name: "IX_SkillMatrixRequirements_PositionId",
            table: "SkillMatrixRequirements",
            column: "PositionId");

        migrationBuilder.CreateIndex(
            name: "IX_TrainingRecords_ConfirmedByUserId",
            table: "TrainingRecords",
            column: "ConfirmedByUserId");

        migrationBuilder.CreateIndex(
            name: "IX_TrainingRecords_CourseId",
            table: "TrainingRecords",
            column: "CourseId");

        migrationBuilder.CreateIndex(
            name: "IX_TrainingRecords_EmployeeId",
            table: "TrainingRecords",
            column: "EmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_TrainingTypes_Name",
            table: "TrainingTypes",
            column: "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            name: "IX_Users_EmployeeId",
            table: "Users",
            column: "EmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_Users_RoleId",
            table: "Users",
            column: "RoleId");

        migrationBuilder.CreateIndex(
            name: "IX_Users_Username",
            table: "Users",
            column: "Username",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "AuditLogs");

        migrationBuilder.DropTable(
            name: "Documents");

        migrationBuilder.DropTable(
            name: "SkillMatrixRequirements");

        migrationBuilder.DropTable(
            name: "TrainingRecords");

        migrationBuilder.DropTable(
            name: "Courses");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "DomainSubcategories");

        migrationBuilder.DropTable(
            name: "TrainingTypes");

        migrationBuilder.DropTable(
            name: "Employees");

        migrationBuilder.DropTable(
            name: "Roles");

        migrationBuilder.DropTable(
            name: "DomainCategories");

        migrationBuilder.DropTable(
            name: "Locations");

        migrationBuilder.DropTable(
            name: "Positions");

        migrationBuilder.DropTable(
            name: "Departments");
    }
}
