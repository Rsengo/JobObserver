using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Employers.Db.Migrations
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
                    ParentId = table.Column<long>(nullable: true)
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
                name: "EMPLOYERS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    AreaId = table.Column<long>(nullable: false),
                    Acronym = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true),
                    TypeId = table.Column<long>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_EMPLOYERS_EMPLOYER_TYPES_TypeId",
                        column: x => x.TypeId,
                        principalTable: "EMPLOYER_TYPES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BRANDED_TEMPLATES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    EmployerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANDED_TEMPLATES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BRANDED_TEMPLATES_EMPLOYERS_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "EMPLOYERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DEPARTMENTS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    OrganizationId1 = table.Column<long>(nullable: true),
                    OrganizationId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPARTMENTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DEPARTMENTS_EMPLOYERS_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "EMPLOYERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DEPARTMENTS_EMPLOYERS_OrganizationId1",
                        column: x => x.OrganizationId1,
                        principalTable: "EMPLOYERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMPLOYER_SYNONYMS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    EmployerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMPLOYER_SYNONYMS", x => x.Id);
                    table.UniqueConstraint("AK_EMPLOYER_SYNONYMS_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_EMPLOYER_SYNONYMS_EMPLOYERS_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "EMPLOYERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PARTNERS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployerId = table.Column<long>(nullable: false),
                    EducationalInstitutionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARTNERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PARTNERS_EMPLOYERS_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "EMPLOYERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AREAS_ParentId",
                table: "AREAS",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BRANDED_TEMPLATES_EmployerId",
                table: "BRANDED_TEMPLATES",
                column: "EmployerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENTS_OrganizationId",
                table: "DEPARTMENTS",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DEPARTMENTS_OrganizationId1",
                table: "DEPARTMENTS",
                column: "OrganizationId1");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYER_SYNONYMS_EmployerId",
                table: "EMPLOYER_SYNONYMS",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYERS_AreaId",
                table: "EMPLOYERS",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_EMPLOYERS_TypeId",
                table: "EMPLOYERS",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PARTNERS_EmployerId",
                table: "PARTNERS",
                column: "EmployerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoHistory");

            migrationBuilder.DropTable(
                name: "BRANDED_TEMPLATES");

            migrationBuilder.DropTable(
                name: "DEPARTMENTS");

            migrationBuilder.DropTable(
                name: "EMPLOYER_SYNONYMS");

            migrationBuilder.DropTable(
                name: "PARTNERS");

            migrationBuilder.DropTable(
                name: "EMPLOYERS");

            migrationBuilder.DropTable(
                name: "AREAS");

            migrationBuilder.DropTable(
                name: "EMPLOYER_TYPES");
        }
    }
}
