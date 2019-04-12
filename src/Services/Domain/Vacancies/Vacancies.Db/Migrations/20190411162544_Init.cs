using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vacancies.Db.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AREAS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<long>(nullable: true),
                    MetroId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AREAS", x => x.Id);
                    table.UniqueConstraint("AK_AREAS_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_AREAS_AREAS_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutoHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RowId = table.Column<string>(maxLength: 50, nullable: false),
                    TableName = table.Column<string>(maxLength: 128, nullable: false),
                    Changed = table.Column<string>(nullable: true),
                    Kind = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CURRENCIES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Abbr = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CURRENCIES", x => x.Id);
                    table.UniqueConstraint("AK_CURRENCIES_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "DRIVING_LICENSE_TYPES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRIVING_LICENSE_TYPES", x => x.Id);
                    table.UniqueConstraint("AK_DRIVING_LICENSE_TYPES_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYMENTS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYMENTS", x => x.Id);
                    table.UniqueConstraint("AK_EMPLOYMENTS_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "INDUSTRIES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INDUSTRIES", x => x.Id);
                    table.UniqueConstraint("AK_INDUSTRIES_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_INDUSTRIES_INDUSTRIES_ParentId",
                        column: x => x.ParentId,
                        principalTable: "INDUSTRIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LANGUAGE_LEVELS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANGUAGE_LEVELS", x => x.Id);
                    table.UniqueConstraint("AK_LANGUAGE_LEVELS_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "LANGUAGES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANGUAGES", x => x.Id);
                    table.UniqueConstraint("AK_LANGUAGES_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "RESPONSES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESPONSES", x => x.Id);
                    table.UniqueConstraint("AK_RESPONSES_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "SCHEDULES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCHEDULES", x => x.Id);
                    table.UniqueConstraint("AK_SCHEDULES_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "SKILLS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKILLS", x => x.Id);
                    table.UniqueConstraint("AK_SKILLS_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "SPECIALIZATIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPECIALIZATIONS", x => x.Id);
                    table.UniqueConstraint("AK_SPECIALIZATIONS_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_SPECIALIZATIONS_SPECIALIZATIONS_ParentId",
                        column: x => x.ParentId,
                        principalTable: "SPECIALIZATIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VACANCY_STATUSES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACANCY_STATUSES", x => x.Id);
                    table.UniqueConstraint("AK_VACANCY_STATUSES_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYERS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    AreaId = table.Column<long>(nullable: true),
                    Acronym = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYERS", x => x.Id);
                    table.UniqueConstraint("AK_EMPLOYERS_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_EMPLOYERS_AREAS_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "METRO",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_METRO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_METRO_AREAS_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    OrganizationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DEPARTMENTS_EMPLOYERS_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "EMPLOYERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LINES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HexColor = table.Column<int>(nullable: false),
                    MetroId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LINES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LINES_METRO_MetroId",
                        column: x => x.MetroId,
                        principalTable: "METRO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "STATIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    LineId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATIONS", x => x.Id);
                    table.UniqueConstraint("AK_STATIONS_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_STATIONS_LINES_LineId",
                        column: x => x.LineId,
                        principalTable: "LINES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ADDRESSES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AreaId = table.Column<long>(nullable: false),
                    Street = table.Column<string>(nullable: false),
                    Building = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    StationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESSES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_AREAS_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ADDRESSES_STATIONS_StationId",
                        column: x => x.StationId,
                        principalTable: "STATIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VACANCIES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    BrandedDescriptionId = table.Column<long>(nullable: true),
                    ScheduleId = table.Column<long>(nullable: true),
                    AcceptHandicapped = table.Column<bool>(nullable: false),
                    AddressId = table.Column<long>(nullable: true),
                    DepartmentId = table.Column<long>(nullable: true),
                    EmploymentId = table.Column<long>(nullable: true),
                    SalaryId = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    PublishedAt = table.Column<DateTime>(nullable: false),
                    EmployerId = table.Column<long>(nullable: false),
                    ResponseLetterRequired = table.Column<bool>(nullable: false),
                    AllowMessages = table.Column<bool>(nullable: false),
                    RequiredVehicle = table.Column<bool>(nullable: false),
                    IsPremium = table.Column<bool>(nullable: false),
                    ExpiresAt = table.Column<DateTime>(nullable: false),
                    ResponseNotification = table.Column<bool>(nullable: false),
                    ManagerId = table.Column<Guid>(nullable: true),
                    VacancyStatusId = table.Column<long>(nullable: false),
                    IndustryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACANCIES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VACANCIES_ADDRESSES_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ADDRESSES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VACANCIES_DEPARTMENTS_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DEPARTMENTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VACANCIES_EMPLOYERS_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "EMPLOYERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VACANCIES_EMPLOYMENTS_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "EMPLOYMENTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VACANCIES_INDUSTRIES_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "INDUSTRIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VACANCIES_SCHEDULES_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "SCHEDULES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VACANCIES_VACANCY_STATUSES_VacancyStatusId",
                        column: x => x.VacancyStatusId,
                        principalTable: "VACANCY_STATUSES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LANGUAGE_SKILLS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LanguageId = table.Column<long>(nullable: false),
                    LevelId = table.Column<long>(nullable: false),
                    VacancyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANGUAGE_SKILLS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LANGUAGE_SKILLS_LANGUAGES_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "LANGUAGES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LANGUAGE_SKILLS_LANGUAGE_LEVELS_LevelId",
                        column: x => x.LevelId,
                        principalTable: "LANGUAGE_LEVELS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LANGUAGE_SKILLS_VACANCIES_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "VACANCIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SALARIES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyId = table.Column<long>(nullable: false),
                    From = table.Column<decimal>(nullable: false),
                    To = table.Column<decimal>(nullable: false),
                    VacancyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALARIES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SALARIES_CURRENCIES_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "CURRENCIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SALARIES_VACANCIES_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "VACANCIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VACANCY_DRIVING_LICENSE_TYPES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VacancyId = table.Column<long>(nullable: false),
                    DrivingLicenseTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACANCY_DRIVING_LICENSE_TYPES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VACANCY_DRIVING_LICENSE_TYPES_DRIVING_LICENSE_TYPES_DrivingLicenseTypeId",
                        column: x => x.DrivingLicenseTypeId,
                        principalTable: "DRIVING_LICENSE_TYPES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VACANCY_DRIVING_LICENSE_TYPES_VACANCIES_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "VACANCIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VACANCY_NEGOTIATIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantId = table.Column<Guid>(nullable: false),
                    VacancyId = table.Column<long>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    ResponseId = table.Column<long>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACANCY_NEGOTIATIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VACANCY_NEGOTIATIONS_RESPONSES_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "RESPONSES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VACANCY_NEGOTIATIONS_VACANCIES_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "VACANCIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VACANCY_SKILLS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VacancyId = table.Column<long>(nullable: false),
                    SkillId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACANCY_SKILLS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VACANCY_SKILLS_SKILLS_SkillId",
                        column: x => x.SkillId,
                        principalTable: "SKILLS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VACANCY_SKILLS_VACANCIES_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "VACANCIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VACANCY_SPECIALIZATIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VacancyId = table.Column<long>(nullable: false),
                    SpecializationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACANCY_SPECIALIZATIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VACANCY_SPECIALIZATIONS_SPECIALIZATIONS_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "SPECIALIZATIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VACANCY_SPECIALIZATIONS_VACANCIES_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "VACANCIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VACANCY_TESTS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    VacancyId = table.Column<long>(nullable: false),
                    TestId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACANCY_TESTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VACANCY_TESTS_VACANCIES_VacancyId",
                        column: x => x.VacancyId,
                        principalTable: "VACANCIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_AreaId",
                table: "ADDRESSES",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESSES_StationId",
                table: "ADDRESSES",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_AREAS_ParentId",
                table: "AREAS",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENTS_OrganizationId",
                table: "DEPARTMENTS",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYERS_AreaId",
                table: "EMPLOYERS",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_INDUSTRIES_ParentId",
                table: "INDUSTRIES",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_LANGUAGE_SKILLS_LanguageId",
                table: "LANGUAGE_SKILLS",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LANGUAGE_SKILLS_LevelId",
                table: "LANGUAGE_SKILLS",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_LANGUAGE_SKILLS_VacancyId",
                table: "LANGUAGE_SKILLS",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_LINES_MetroId",
                table: "LINES",
                column: "MetroId");

            migrationBuilder.CreateIndex(
                name: "IX_METRO_AreaId",
                table: "METRO",
                column: "AreaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SALARIES_CurrencyId",
                table: "SALARIES",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SALARIES_VacancyId",
                table: "SALARIES",
                column: "VacancyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SPECIALIZATIONS_ParentId",
                table: "SPECIALIZATIONS",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_STATIONS_LineId",
                table: "STATIONS",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_AddressId",
                table: "VACANCIES",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_DepartmentId",
                table: "VACANCIES",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_EmployerId",
                table: "VACANCIES",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_EmploymentId",
                table: "VACANCIES",
                column: "EmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_IndustryId",
                table: "VACANCIES",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_ScheduleId",
                table: "VACANCIES",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCIES_VacancyStatusId",
                table: "VACANCIES",
                column: "VacancyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCY_DRIVING_LICENSE_TYPES_DrivingLicenseTypeId",
                table: "VACANCY_DRIVING_LICENSE_TYPES",
                column: "DrivingLicenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCY_DRIVING_LICENSE_TYPES_VacancyId",
                table: "VACANCY_DRIVING_LICENSE_TYPES",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCY_NEGOTIATIONS_ResponseId",
                table: "VACANCY_NEGOTIATIONS",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCY_NEGOTIATIONS_VacancyId",
                table: "VACANCY_NEGOTIATIONS",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCY_SKILLS_SkillId",
                table: "VACANCY_SKILLS",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCY_SKILLS_VacancyId",
                table: "VACANCY_SKILLS",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCY_SPECIALIZATIONS_SpecializationId",
                table: "VACANCY_SPECIALIZATIONS",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCY_SPECIALIZATIONS_VacancyId",
                table: "VACANCY_SPECIALIZATIONS",
                column: "VacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_VACANCY_TESTS_VacancyId",
                table: "VACANCY_TESTS",
                column: "VacancyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoHistory");

            migrationBuilder.DropTable(
                name: "LANGUAGE_SKILLS");

            migrationBuilder.DropTable(
                name: "SALARIES");

            migrationBuilder.DropTable(
                name: "VACANCY_DRIVING_LICENSE_TYPES");

            migrationBuilder.DropTable(
                name: "VACANCY_NEGOTIATIONS");

            migrationBuilder.DropTable(
                name: "VACANCY_SKILLS");

            migrationBuilder.DropTable(
                name: "VACANCY_SPECIALIZATIONS");

            migrationBuilder.DropTable(
                name: "VACANCY_TESTS");

            migrationBuilder.DropTable(
                name: "LANGUAGES");

            migrationBuilder.DropTable(
                name: "LANGUAGE_LEVELS");

            migrationBuilder.DropTable(
                name: "CURRENCIES");

            migrationBuilder.DropTable(
                name: "DRIVING_LICENSE_TYPES");

            migrationBuilder.DropTable(
                name: "RESPONSES");

            migrationBuilder.DropTable(
                name: "SKILLS");

            migrationBuilder.DropTable(
                name: "SPECIALIZATIONS");

            migrationBuilder.DropTable(
                name: "VACANCIES");

            migrationBuilder.DropTable(
                name: "ADDRESSES");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "EMPLOYMENTS");

            migrationBuilder.DropTable(
                name: "INDUSTRIES");

            migrationBuilder.DropTable(
                name: "SCHEDULES");

            migrationBuilder.DropTable(
                name: "VACANCY_STATUSES");

            migrationBuilder.DropTable(
                name: "STATIONS");

            migrationBuilder.DropTable(
                name: "EMPLOYERS");

            migrationBuilder.DropTable(
                name: "LINES");

            migrationBuilder.DropTable(
                name: "METRO");

            migrationBuilder.DropTable(
                name: "AREAS");
        }
    }
}
