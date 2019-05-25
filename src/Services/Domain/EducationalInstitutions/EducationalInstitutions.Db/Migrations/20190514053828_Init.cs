using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationalInstitutions.Db.Migrations
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
                name: "BRANDED_TEMPLATES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRANDED_TEMPLATES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EDUCATIONAL_INSTITUTIONS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Acronym = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BrandedDescriptionId = table.Column<long>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true),
                    AreaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDUCATIONAL_INSTITUTIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EDUCATIONAL_INSTITUTIONS_AREAS_AreaId",
                        column: x => x.AreaId,
                        principalTable: "AREAS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EDUCATIONAL_INSTITUTIONS_BRANDED_TEMPLATES_BrandedDescriptionId",
                        column: x => x.BrandedDescriptionId,
                        principalTable: "BRANDED_TEMPLATES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EDUCATIONAL_iNSTITUTION_SYNONYMS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    EducationalInstitutionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDUCATIONAL_iNSTITUTION_SYNONYMS", x => x.Id);
                    table.UniqueConstraint("AK_EDUCATIONAL_iNSTITUTION_SYNONYMS_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_EDUCATIONAL_iNSTITUTION_SYNONYMS_EDUCATIONAL_INSTITUTIONS_EducationalInstitutionId",
                        column: x => x.EducationalInstitutionId,
                        principalTable: "EDUCATIONAL_INSTITUTIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FACULTIES",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Acronym = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BrandedDescriptionId = table.Column<long>(nullable: true),
                    LogoUrl = table.Column<string>(nullable: true),
                    SiteUrl = table.Column<string>(nullable: true),
                    EducationalInstitutionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACULTIES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FACULTIES_BRANDED_TEMPLATES_BrandedDescriptionId",
                        column: x => x.BrandedDescriptionId,
                        principalTable: "BRANDED_TEMPLATES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FACULTIES_EDUCATIONAL_INSTITUTIONS_EducationalInstitutionId",
                        column: x => x.EducationalInstitutionId,
                        principalTable: "EDUCATIONAL_INSTITUTIONS",
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
                        name: "FK_PARTNERS_EDUCATIONAL_INSTITUTIONS_EducationalInstitutionId",
                        column: x => x.EducationalInstitutionId,
                        principalTable: "EDUCATIONAL_INSTITUTIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FACULTY_SYNONYMS",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    FacultyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACULTY_SYNONYMS", x => x.Id);
                    table.UniqueConstraint("AK_FACULTY_SYNONYMS_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_FACULTY_SYNONYMS_FACULTIES_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "FACULTIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AREAS_ParentId",
                table: "AREAS",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_EDUCATIONAL_iNSTITUTION_SYNONYMS_EducationalInstitutionId",
                table: "EDUCATIONAL_iNSTITUTION_SYNONYMS",
                column: "EducationalInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_EDUCATIONAL_INSTITUTIONS_AreaId",
                table: "EDUCATIONAL_INSTITUTIONS",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_EDUCATIONAL_INSTITUTIONS_BrandedDescriptionId",
                table: "EDUCATIONAL_INSTITUTIONS",
                column: "BrandedDescriptionId",
                unique: true,
                filter: "[BrandedDescriptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FACULTIES_BrandedDescriptionId",
                table: "FACULTIES",
                column: "BrandedDescriptionId",
                unique: true,
                filter: "[BrandedDescriptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FACULTIES_EducationalInstitutionId",
                table: "FACULTIES",
                column: "EducationalInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_FACULTY_SYNONYMS_FacultyId",
                table: "FACULTY_SYNONYMS",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_PARTNERS_EducationalInstitutionId",
                table: "PARTNERS",
                column: "EducationalInstitutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoHistory");

            migrationBuilder.DropTable(
                name: "EDUCATIONAL_iNSTITUTION_SYNONYMS");

            migrationBuilder.DropTable(
                name: "FACULTY_SYNONYMS");

            migrationBuilder.DropTable(
                name: "PARTNERS");

            migrationBuilder.DropTable(
                name: "FACULTIES");

            migrationBuilder.DropTable(
                name: "EDUCATIONAL_INSTITUTIONS");

            migrationBuilder.DropTable(
                name: "AREAS");

            migrationBuilder.DropTable(
                name: "BRANDED_TEMPLATES");
        }
    }
}
