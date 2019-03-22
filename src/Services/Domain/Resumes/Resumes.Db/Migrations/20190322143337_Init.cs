using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resumes.Db.Migrations
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
                name: "BUSINESS_TRIP_READINESS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUSINESS_TRIP_READINESS", x => x.Id);
                    table.UniqueConstraint("AK_BUSINESS_TRIP_READINESS_Name", x => x.Name);
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
                name: "EDUCATIONAL_LEVELS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDUCATIONAL_LEVELS", x => x.Id);
                    table.UniqueConstraint("AK_EDUCATIONAL_LEVELS_Name", x => x.Name);
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
                name: "GENDERS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GENDERS", x => x.Id);
                    table.UniqueConstraint("AK_GENDERS_Name", x => x.Name);
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
                name: "RELOCATION_TYPES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RELOCATION_TYPES", x => x.Id);
                    table.UniqueConstraint("AK_RELOCATION_TYPES_Name", x => x.Name);
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
                name: "RESUME_STATUSES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUME_STATUSES", x => x.Id);
                    table.UniqueConstraint("AK_RESUME_STATUSES_Name", x => x.Name);
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
                name: "TRAVEL_TIMES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRAVEL_TIMES", x => x.Id);
                    table.UniqueConstraint("AK_TRAVEL_TIMES_Name", x => x.Name);
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
                name: "APPLICANTS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    GenderId = table.Column<long>(nullable: false),
                    AreaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPLICANTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_APPLICANTS_AREAS_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APPLICANTS_GENDERS_GenderId",
                        column: x => x.GenderId,
                        principalTable: "GENDERS",
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
                name: "RESUMES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicantId = table.Column<Guid>(nullable: false),
                    AreaId = table.Column<long>(nullable: true),
                    MetroStationId = table.Column<long>(nullable: true),
                    BusinessTripReadinessId = table.Column<long>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    PhotoUrl = table.Column<string>(nullable: true),
                    SalaryId = table.Column<long>(nullable: true),
                    TravelTimeId = table.Column<long>(nullable: true),
                    ResumeLocaleId = table.Column<long>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    HasVehicle = table.Column<bool>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    IsPremium = table.Column<bool>(nullable: false),
                    ResumeStatusId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUMES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESUMES_APPLICANTS_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "APPLICANTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RESUMES_AREAS_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUMES_BUSINESS_TRIP_READINESS_BusinessTripReadinessId",
                        column: x => x.BusinessTripReadinessId,
                        principalTable: "BUSINESS_TRIP_READINESS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUMES_STATIONS_MetroStationId",
                        column: x => x.MetroStationId,
                        principalTable: "STATIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUMES_LANGUAGES_ResumeLocaleId",
                        column: x => x.ResumeLocaleId,
                        principalTable: "LANGUAGES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUMES_RESUME_STATUSES_ResumeStatusId",
                        column: x => x.ResumeStatusId,
                        principalTable: "RESUME_STATUSES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUMES_TRAVEL_TIMES_TravelTimeId",
                        column: x => x.TravelTimeId,
                        principalTable: "TRAVEL_TIMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CERTIFICATES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false),
                    ResumeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CERTIFICATES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CERTIFICATES_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CITIZENSHIPS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<long>(nullable: false),
                    AreaId = table.Column<long>(nullable: false),
                    ResumeId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CITIZENSHIPS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CITIZENSHIPS_AREAS_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CITIZENSHIPS_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CITIZENSHIPS_RESUMES_ResumeId1",
                        column: x => x.ResumeId1,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDUCATIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EducationalLevelId = table.Column<long>(nullable: false),
                    School = table.Column<string>(nullable: true),
                    FacultyId = table.Column<long>(nullable: false),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    GraduationDate = table.Column<DateTime>(nullable: false),
                    ResumeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDUCATIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDUCATIONS_EDUCATIONAL_LEVELS_EducationalLevelId",
                        column: x => x.EducationalLevelId,
                        principalTable: "EDUCATIONAL_LEVELS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDUCATIONS_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EXPERIENCES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<long>(nullable: false),
                    IndustryId = table.Column<long>(nullable: false),
                    SpecializationId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    StartedAt = table.Column<DateTime>(nullable: false),
                    EndAt = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ResumeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPERIENCES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EXPERIENCES_INDUSTRIES_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "INDUSTRIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EXPERIENCES_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EXPERIENCES_SPECIALIZATIONS_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "SPECIALIZATIONS",
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
                    ResumeId = table.Column<long>(nullable: false)
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
                        name: "FK_LANGUAGE_SKILLS_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RELOCATION_POSSIBILITIES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RelocationTypeId = table.Column<long>(nullable: false),
                    AreaId = table.Column<long>(nullable: false),
                    ResumeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RELOCATION_POSSIBILITIES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RELOCATION_POSSIBILITIES_AREAS_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RELOCATION_POSSIBILITIES_RELOCATION_TYPES_RelocationTypeId",
                        column: x => x.RelocationTypeId,
                        principalTable: "RELOCATION_TYPES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RELOCATION_POSSIBILITIES_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESUME_DRIVING_LICENSE_TYPES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<long>(nullable: false),
                    DrivingLicenseTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUME_DRIVING_LICENSE_TYPES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESUME_DRIVING_LICENSE_TYPES_DRIVING_LICENSE_TYPES_DrivingLicenseTypeId",
                        column: x => x.DrivingLicenseTypeId,
                        principalTable: "DRIVING_LICENSE_TYPES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUME_DRIVING_LICENSE_TYPES_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESUME_EMPLOYMENTS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<long>(nullable: false),
                    EmploymentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUME_EMPLOYMENTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESUME_EMPLOYMENTS_EMPLOYMENTS_EmploymentId",
                        column: x => x.EmploymentId,
                        principalTable: "EMPLOYMENTS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUME_EMPLOYMENTS_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESUME_NEGOTIATIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<long>(nullable: false),
                    ResumeId = table.Column<long>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    ResponseId = table.Column<long>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUME_NEGOTIATIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESUME_NEGOTIATIONS_RESPONSES_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "RESPONSES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUME_NEGOTIATIONS_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESUME_SCHEDULES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<long>(nullable: false),
                    ScheduleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUME_SCHEDULES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESUME_SCHEDULES_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUME_SCHEDULES_SCHEDULES_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "SCHEDULES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESUME_SKILLS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<long>(nullable: false),
                    SkillId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUME_SKILLS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESUME_SKILLS_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUME_SKILLS_SKILLS_SkillId",
                        column: x => x.SkillId,
                        principalTable: "SKILLS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RESUME_SPECIALIZATIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<long>(nullable: false),
                    SpecializationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESUME_SPECIALIZATIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESUME_SPECIALIZATIONS_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RESUME_SPECIALIZATIONS_SPECIALIZATIONS_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "SPECIALIZATIONS",
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
                    ResumeId = table.Column<long>(nullable: false)
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
                        name: "FK_SALARIES_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WORK_TICKETS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResumeId = table.Column<long>(nullable: false),
                    AreaId = table.Column<long>(nullable: false),
                    ResumeId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WORK_TICKETS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WORK_TICKETS_AREAS_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WORK_TICKETS_RESUMES_ResumeId",
                        column: x => x.ResumeId,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WORK_TICKETS_RESUMES_ResumeId1",
                        column: x => x.ResumeId1,
                        principalTable: "RESUMES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EDUCATION_SPECIALIZATIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EducationId = table.Column<long>(nullable: false),
                    SpecializationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDUCATION_SPECIALIZATIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDUCATION_SPECIALIZATIONS_EDUCATIONS_EducationId",
                        column: x => x.EducationId,
                        principalTable: "EDUCATIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDUCATION_SPECIALIZATIONS_SPECIALIZATIONS_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "SPECIALIZATIONS",
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
                name: "IX_APPLICANTS_AreaId",
                table: "APPLICANTS",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_APPLICANTS_GenderId",
                table: "APPLICANTS",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AREAS_ParentId",
                table: "AREAS",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CERTIFICATES_ResumeId",
                table: "CERTIFICATES",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_CITIZENSHIPS_AreaId",
                table: "CITIZENSHIPS",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CITIZENSHIPS_ResumeId",
                table: "CITIZENSHIPS",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_CITIZENSHIPS_ResumeId1",
                table: "CITIZENSHIPS",
                column: "ResumeId1");

            migrationBuilder.CreateIndex(
                name: "IX_EDUCATION_SPECIALIZATIONS_EducationId",
                table: "EDUCATION_SPECIALIZATIONS",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_EDUCATION_SPECIALIZATIONS_SpecializationId",
                table: "EDUCATION_SPECIALIZATIONS",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_EDUCATIONS_EducationalLevelId",
                table: "EDUCATIONS",
                column: "EducationalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EDUCATIONS_ResumeId",
                table: "EDUCATIONS",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_EXPERIENCES_IndustryId",
                table: "EXPERIENCES",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_EXPERIENCES_ResumeId",
                table: "EXPERIENCES",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_EXPERIENCES_SpecializationId",
                table: "EXPERIENCES",
                column: "SpecializationId");

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
                name: "IX_LANGUAGE_SKILLS_ResumeId",
                table: "LANGUAGE_SKILLS",
                column: "ResumeId");

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
                name: "IX_RELOCATION_POSSIBILITIES_AreaId",
                table: "RELOCATION_POSSIBILITIES",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_RELOCATION_POSSIBILITIES_RelocationTypeId",
                table: "RELOCATION_POSSIBILITIES",
                column: "RelocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RELOCATION_POSSIBILITIES_ResumeId",
                table: "RELOCATION_POSSIBILITIES",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_DRIVING_LICENSE_TYPES_DrivingLicenseTypeId",
                table: "RESUME_DRIVING_LICENSE_TYPES",
                column: "DrivingLicenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_DRIVING_LICENSE_TYPES_ResumeId",
                table: "RESUME_DRIVING_LICENSE_TYPES",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_EMPLOYMENTS_EmploymentId",
                table: "RESUME_EMPLOYMENTS",
                column: "EmploymentId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_EMPLOYMENTS_ResumeId",
                table: "RESUME_EMPLOYMENTS",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_NEGOTIATIONS_ResponseId",
                table: "RESUME_NEGOTIATIONS",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_NEGOTIATIONS_ResumeId",
                table: "RESUME_NEGOTIATIONS",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_SCHEDULES_ResumeId",
                table: "RESUME_SCHEDULES",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_SCHEDULES_ScheduleId",
                table: "RESUME_SCHEDULES",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_SKILLS_ResumeId",
                table: "RESUME_SKILLS",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_SKILLS_SkillId",
                table: "RESUME_SKILLS",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_SPECIALIZATIONS_ResumeId",
                table: "RESUME_SPECIALIZATIONS",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUME_SPECIALIZATIONS_SpecializationId",
                table: "RESUME_SPECIALIZATIONS",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMES_ApplicantId",
                table: "RESUMES",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMES_AreaId",
                table: "RESUMES",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMES_BusinessTripReadinessId",
                table: "RESUMES",
                column: "BusinessTripReadinessId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMES_MetroStationId",
                table: "RESUMES",
                column: "MetroStationId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMES_ResumeLocaleId",
                table: "RESUMES",
                column: "ResumeLocaleId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMES_ResumeStatusId",
                table: "RESUMES",
                column: "ResumeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMES_SalaryId",
                table: "RESUMES",
                column: "SalaryId");

            migrationBuilder.CreateIndex(
                name: "IX_RESUMES_TravelTimeId",
                table: "RESUMES",
                column: "TravelTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_SALARIES_CurrencyId",
                table: "SALARIES",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SALARIES_ResumeId",
                table: "SALARIES",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_SPECIALIZATIONS_ParentId",
                table: "SPECIALIZATIONS",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_STATIONS_LineId",
                table: "STATIONS",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_WORK_TICKETS_AreaId",
                table: "WORK_TICKETS",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_WORK_TICKETS_ResumeId",
                table: "WORK_TICKETS",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_WORK_TICKETS_ResumeId1",
                table: "WORK_TICKETS",
                column: "ResumeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RESUMES_SALARIES_SalaryId",
                table: "RESUMES",
                column: "SalaryId",
                principalTable: "SALARIES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APPLICANTS_AREAS_AreaId",
                table: "APPLICANTS");

            migrationBuilder.DropForeignKey(
                name: "FK_METRO_AREAS_AreaId",
                table: "METRO");

            migrationBuilder.DropForeignKey(
                name: "FK_RESUMES_AREAS_AreaId",
                table: "RESUMES");

            migrationBuilder.DropForeignKey(
                name: "FK_RESUMES_STATIONS_MetroStationId",
                table: "RESUMES");

            migrationBuilder.DropForeignKey(
                name: "FK_APPLICANTS_GENDERS_GenderId",
                table: "APPLICANTS");

            migrationBuilder.DropForeignKey(
                name: "FK_SALARIES_RESUMES_ResumeId",
                table: "SALARIES");

            migrationBuilder.DropTable(
                name: "ADDRESSES");

            migrationBuilder.DropTable(
                name: "AutoHistory");

            migrationBuilder.DropTable(
                name: "CERTIFICATES");

            migrationBuilder.DropTable(
                name: "CITIZENSHIPS");

            migrationBuilder.DropTable(
                name: "EDUCATION_SPECIALIZATIONS");

            migrationBuilder.DropTable(
                name: "EXPERIENCES");

            migrationBuilder.DropTable(
                name: "LANGUAGE_SKILLS");

            migrationBuilder.DropTable(
                name: "RELOCATION_POSSIBILITIES");

            migrationBuilder.DropTable(
                name: "RESUME_DRIVING_LICENSE_TYPES");

            migrationBuilder.DropTable(
                name: "RESUME_EMPLOYMENTS");

            migrationBuilder.DropTable(
                name: "RESUME_NEGOTIATIONS");

            migrationBuilder.DropTable(
                name: "RESUME_SCHEDULES");

            migrationBuilder.DropTable(
                name: "RESUME_SKILLS");

            migrationBuilder.DropTable(
                name: "RESUME_SPECIALIZATIONS");

            migrationBuilder.DropTable(
                name: "WORK_TICKETS");

            migrationBuilder.DropTable(
                name: "EDUCATIONS");

            migrationBuilder.DropTable(
                name: "INDUSTRIES");

            migrationBuilder.DropTable(
                name: "LANGUAGE_LEVELS");

            migrationBuilder.DropTable(
                name: "RELOCATION_TYPES");

            migrationBuilder.DropTable(
                name: "DRIVING_LICENSE_TYPES");

            migrationBuilder.DropTable(
                name: "EMPLOYMENTS");

            migrationBuilder.DropTable(
                name: "RESPONSES");

            migrationBuilder.DropTable(
                name: "SCHEDULES");

            migrationBuilder.DropTable(
                name: "SKILLS");

            migrationBuilder.DropTable(
                name: "SPECIALIZATIONS");

            migrationBuilder.DropTable(
                name: "EDUCATIONAL_LEVELS");

            migrationBuilder.DropTable(
                name: "AREAS");

            migrationBuilder.DropTable(
                name: "STATIONS");

            migrationBuilder.DropTable(
                name: "LINES");

            migrationBuilder.DropTable(
                name: "METRO");

            migrationBuilder.DropTable(
                name: "GENDERS");

            migrationBuilder.DropTable(
                name: "RESUMES");

            migrationBuilder.DropTable(
                name: "APPLICANTS");

            migrationBuilder.DropTable(
                name: "BUSINESS_TRIP_READINESS");

            migrationBuilder.DropTable(
                name: "LANGUAGES");

            migrationBuilder.DropTable(
                name: "RESUME_STATUSES");

            migrationBuilder.DropTable(
                name: "SALARIES");

            migrationBuilder.DropTable(
                name: "TRAVEL_TIMES");

            migrationBuilder.DropTable(
                name: "CURRENCIES");
        }
    }
}
