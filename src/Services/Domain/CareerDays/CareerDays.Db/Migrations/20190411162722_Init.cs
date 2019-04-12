using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CareerDays.Db.Migrations
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
                name: "EDUCATIONAL_INSTITUTIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    LogoUrl = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDUCATIONAL_INSTITUTIONS", x => x.Id);
                    table.UniqueConstraint("AK_EDUCATIONAL_INSTITUTIONS_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYERS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    LogoUrl = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYERS", x => x.Id);
                    table.UniqueConstraint("AK_EMPLOYERS_Name", x => x.Name);
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
                name: "CAREER_DAYS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    BrandedDescriptionId = table.Column<long>(nullable: true),
                    StartsAt = table.Column<DateTime>(nullable: false),
                    EmployerId = table.Column<long>(nullable: false),
                    EducationalInstitutionId = table.Column<long>(nullable: true),
                    AddressId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAREER_DAYS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CAREER_DAYS_ADDRESSES_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ADDRESSES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CAREER_DAY_EDUCATIONAL_INSTITUTIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EducationalInstitutionId = table.Column<long>(nullable: false),
                    CareerDayId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAREER_DAY_EDUCATIONAL_INSTITUTIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CAREER_DAY_EDUCATIONAL_INSTITUTIONS_CAREER_DAYS_CareerDayId",
                        column: x => x.CareerDayId,
                        principalTable: "CAREER_DAYS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CAREER_DAY_EDUCATIONAL_INSTITUTIONS_EDUCATIONAL_INSTITUTIONS_EducationalInstitutionId",
                        column: x => x.EducationalInstitutionId,
                        principalTable: "EDUCATIONAL_INSTITUTIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CAREER_DAY_EMPLOYERS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployerId = table.Column<long>(nullable: false),
                    CareerDayId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAREER_DAY_EMPLOYERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CAREER_DAY_EMPLOYERS_CAREER_DAYS_CareerDayId",
                        column: x => x.CareerDayId,
                        principalTable: "CAREER_DAYS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CAREER_DAY_EMPLOYERS_EMPLOYERS_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "EMPLOYERS",
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
                name: "IX_CAREER_DAY_EDUCATIONAL_INSTITUTIONS_CareerDayId",
                table: "CAREER_DAY_EDUCATIONAL_INSTITUTIONS",
                column: "CareerDayId");

            migrationBuilder.CreateIndex(
                name: "IX_CAREER_DAY_EDUCATIONAL_INSTITUTIONS_EducationalInstitutionId",
                table: "CAREER_DAY_EDUCATIONAL_INSTITUTIONS",
                column: "EducationalInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_CAREER_DAY_EMPLOYERS_CareerDayId",
                table: "CAREER_DAY_EMPLOYERS",
                column: "CareerDayId");

            migrationBuilder.CreateIndex(
                name: "IX_CAREER_DAY_EMPLOYERS_EmployerId",
                table: "CAREER_DAY_EMPLOYERS",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_CAREER_DAYS_AddressId",
                table: "CAREER_DAYS",
                column: "AddressId");

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
                name: "IX_STATIONS_LineId",
                table: "STATIONS",
                column: "LineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoHistory");

            migrationBuilder.DropTable(
                name: "CAREER_DAY_EDUCATIONAL_INSTITUTIONS");

            migrationBuilder.DropTable(
                name: "CAREER_DAY_EMPLOYERS");

            migrationBuilder.DropTable(
                name: "EDUCATIONAL_INSTITUTIONS");

            migrationBuilder.DropTable(
                name: "CAREER_DAYS");

            migrationBuilder.DropTable(
                name: "EMPLOYERS");

            migrationBuilder.DropTable(
                name: "ADDRESSES");

            migrationBuilder.DropTable(
                name: "STATIONS");

            migrationBuilder.DropTable(
                name: "LINES");

            migrationBuilder.DropTable(
                name: "METRO");

            migrationBuilder.DropTable(
                name: "AREAS");
        }
    }
}
