Codex Prompt — Build Plan + Next Steps
Context

You are working inside an existing repo folder named Training database interface. Implement a Windows desktop training compliance application per the specification below. Follow the step-by-step plan and keep each stage buildable.

Local setup (Phase 1)
- Prerequisites: .NET 8 SDK, SQL Server Express.
- Connection string: update `src/TrainingDatabaseInterface.App/appsettings.json` if your SQL Server Express instance is not `localhost\SQLEXPRESS`.
- Migrations: `dotnet ef migrations add InitialCreate --project src/TrainingDatabaseInterface.Data --startup-project src/TrainingDatabaseInterface.App`
- Apply DB: `dotnet ef database update --project src/TrainingDatabaseInterface.Data --startup-project src/TrainingDatabaseInterface.App`
- Default admin credentials: `admin` / `Admin!123`

Product Summary (what to build)

Build a .NET 8 WPF Windows desktop app that connects to a shared SQL Server Express database. The app manages employee training compliance using a Skills Matrix (Courses × Positions) with requirement codes M (Mandatory) and D (Designated). It provides role-based access (Admin/Trainer/Manager/Employee), KPI dashboards with filtering, reporting exports, a compliance pivot matrix (Employees × Courses grouped by domain), and a local evidence document store at %LOCALAPPDATA%\TrainingTracker\docs\ (provider-based so SharePoint can be added later).

(Use the full specification from my previous message as the authoritative feature list.)

Execution rules

Keep changes incremental and compile/run at the end of each phase.

Prefer clean, standard WPF patterns: MVVM, ResourceDictionaries for styling, async DB calls.

Use SQL Server Express as the primary DB target.

Implement concurrency (RowVersion) and audit logging.

Trainers: global view; can add/confirm training records + upload evidence; cannot modify courses/matrix/employees.

Managers: direct reports only (Employee.LineManagerEmployeeId = Manager.EmployeeId).

Employees: self only.

Next Steps (Implementation Plan)
Phase 0 — Repository inspection and setup

Inspect current repo structure. If empty, create:

/src/TrainingDatabaseInterface.App/ (WPF app)

/src/TrainingDatabaseInterface.Core/ (domain models, services)

/src/TrainingDatabaseInterface.Data/ (EF Core + migrations)

/src/TrainingDatabaseInterface.Tests/ (optional, unit tests)

Add a solution file at /src/TrainingDatabaseInterface.sln.

Add README.md with:

prerequisites (.NET 8 SDK, SQL Server Express)

how to configure connection string

how to run migrations/initialize DB

how to build Release exe

Default admin credentials (Phase 1 seed):
- Username: admin
- Password: Admin!123

Deliverable: Solution builds successfully with an empty shell window.

Phase 1 — Database schema + migrations (SQL Server Express)

Implement EF Core for SQL Server with migrations.

Create tables and constraints for:

Users (auth)

Roles

Locations

Departments

Positions (FK Department)

Employees (unique EmployeeNumber + unique Email, line manager FK)

Courses (domain category/subcategory, training type, vendor fields, competency months, duration hours, default trainer)

DomainCategory, DomainSubcategory

TrainingType (lookup)

SkillMatrixRequirement (M/D/blank via RequirementCode; supports location override)

TrainingRecords (append-only)

Documents (provider-based metadata)

AuditLog

Add RowVersion (timestamp) concurrency columns on key tables.

Seed data:

Admin user (default credentials documented in README)

baseline TrainingTypes (In-person, Online, Virtual ILT, Blended, External Vendor)

optional sample domain categories

Deliverable: Migration runs and creates DB; seed completes.

Phase 2 — Authentication + role-based authorization

Build login window.

Implement password hashing + verification.

Implement session context (current user, role, linked EmployeeId).

Implement authorization checks to enable/disable navigation items and actions by role.

Write AuditLog entries for logins.

Deliverable: You can log in as Admin and reach the app shell; role gating works.

Phase 3 — App shell + style system (Figma-ready)

Create the main shell:

Top bar + left nav + content frame

Implement enterprise light theme:

neutral background, single accent color

status badge colors for compliance states

Implement common components:

FilterBar control

KPI Tile control

DataTable styling

Deliverable: Navigation works; placeholder pages render with correct styling.

Phase 4 — Course Catalog (read-only for all; Admin edit)

Build Courses list page:

search + filters (Domain, TrainingType, external, active)

Course details page:

display all fields

Admin-only course editor:

create/edit/deactivate

manage Domain categories/subcategories and TrainingTypes (simple admin editor screens)

Deliverable: All roles can view course list; only Admin can edit.

Phase 5 — Org & Employee management (Admin-only edit; view scoped)

Admin screens to manage:

Locations, Departments, Positions

Employees:

Admin can create/edit employees and assign manager

Unique EmployeeNumber + Email enforced

Role scope behavior:

Manager sees only direct reports

Trainer sees all

Employee sees self

Deliverable: Employee list respects scope; employee detail renders.

Phase 6 — Skills Matrix (Admin-only)

Implement matrix UI:

Department selector required

Location selector optional (overrides)

Rows = courses; columns = positions

Cell cycle blank → M → D → blank

Persist to SkillMatrixRequirement with override precedence.

Deliverable: Admin can configure M/D requirements; requirements resolve correctly.

Phase 7 — Training record entry + evidence documents

Training entry page (Trainer/Admin):

select employee + course + completion date

evidence note

Document storage provider v1 (Local):

copy uploaded files into %LOCALAPPDATA%\TrainingTracker\docs\...

store provider metadata in Documents table

Link documents to training records.

AuditLog for new training records and uploads.

Deliverable: Trainer can confirm training and attach evidence; files open from the app.

Phase 8 — Compliance engine + KPI dashboards

Implement requirement resolution:

department+position base + optional location override

Implement compliance status:

month-based expiry (CompetencyLengthMonths)

KPIs:

Mandatory: Missing/Expired/Expiring 0–30/31–60/61–90

Designated: Expired/Expiring buckets

Filters:

site, department, manager (Admin/Trainer), course domain, training type

Drill-down table + CSV export

Deliverable: KPIs match compliance logic; filters and drill-down exports work.

Phase 9 — Compliance Pivot (Employee × Course grouped by domain)

Pivot page:

rows: employees (sticky)

columns: courses grouped by domain (sticky)

filters: department, site, domain, all vs expiry courses

Colors:

green compliant

yellow expiring ≤90

red missing/expired with glyph overlay: ! missing, X expired

Designated OFF by default toggle

Export:

Excel-like export (or CSV + formatting guidance) and normalized export

Deliverable: Pivot renders efficiently with virtualization; exports work.

Phase 10 — Reporting suite

Implement reports with filters and CSV export:

Compliance summary

Expiring soon detail

Employee transcript

Course compliance report

Training hours report (duration hours, vendor/domain grouping)

Deliverable: Reports run fast and respect role scope.

Phase 11 — Release packaging

Build Release configuration.

Create a publish profile that outputs a distributable exe.

Update README with exact build/publish steps.

Deliverable: Release build produces a working exe.

Acceptance checks (must pass)

Manager sees only direct reports everywhere (KPIs, pivot, reports, employees).

Course list is visible to all roles.

Skills Matrix defines requirements with M/D and location overrides.

Expiry uses calendar months.

Pivot colors and glyph overlays exactly match spec.

Evidence documents are copied into %LOCALAPPDATA%\TrainingTracker\docs\ and open reliably.

CSV exports work for drill-downs and reports.
