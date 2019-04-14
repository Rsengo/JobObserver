using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dictionaries.Db.Migrations
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
                    table.ForeignKey(
                        name: "FK_AREAS_AREAS_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Abbr = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
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
                name: "EMPLOYER_TYPES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYER_TYPES", x => x.Id);
                    table.UniqueConstraint("AK_EMPLOYER_TYPES_Name", x => x.Name);
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
                name: "SITE_TYPES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITE_TYPES", x => x.Id);
                    table.UniqueConstraint("AK_SITE_TYPES_Name", x => x.Name);
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

            migrationBuilder.CreateIndex(
                name: "IX_AREAS_ParentId",
                table: "AREAS",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_INDUSTRIES_ParentId",
                table: "INDUSTRIES",
                column: "ParentId");

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
                name: "IX_SPECIALIZATIONS_ParentId",
                table: "SPECIALIZATIONS",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_STATIONS_LineId",
                table: "STATIONS",
                column: "LineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BUSINESS_TRIP_READINESS");

            migrationBuilder.DropTable(
                name: "CURRENCIES");

            migrationBuilder.DropTable(
                name: "DRIVING_LICENSE_TYPES");

            migrationBuilder.DropTable(
                name: "EDUCATIONAL_LEVELS");

            migrationBuilder.DropTable(
                name: "EMPLOYER_TYPES");

            migrationBuilder.DropTable(
                name: "EMPLOYMENTS");

            migrationBuilder.DropTable(
                name: "GENDERS");

            migrationBuilder.DropTable(
                name: "INDUSTRIES");

            migrationBuilder.DropTable(
                name: "LANGUAGE_LEVELS");

            migrationBuilder.DropTable(
                name: "LANGUAGES");

            migrationBuilder.DropTable(
                name: "RELOCATION_TYPES");

            migrationBuilder.DropTable(
                name: "RESPONSES");

            migrationBuilder.DropTable(
                name: "RESUME_STATUSES");

            migrationBuilder.DropTable(
                name: "SCHEDULES");

            migrationBuilder.DropTable(
                name: "SITE_TYPES");

            migrationBuilder.DropTable(
                name: "SKILLS");

            migrationBuilder.DropTable(
                name: "SPECIALIZATIONS");

            migrationBuilder.DropTable(
                name: "STATIONS");

            migrationBuilder.DropTable(
                name: "TRAVEL_TIMES");

            migrationBuilder.DropTable(
                name: "VACANCY_STATUSES");

            migrationBuilder.DropTable(
                name: "LINES");

            migrationBuilder.DropTable(
                name: "METRO");

            migrationBuilder.DropTable(
                name: "AREAS");
        }
    }
}
