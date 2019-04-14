﻿// <auto-generated />
using System;
using EducationalInstitutions.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EducationalInstitutions.Db.Migrations
{
    [DbContext(typeof(EducationalInstitutionsDbContext))]
    partial class EducationalInstitutionsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EducationalInstitutions.Db.Models.EducationalInstitution", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acronym");

                    b.Property<long?>("AreaId")
                        .IsRequired();

                    b.Property<long?>("BrandedDescriptionId");

                    b.Property<string>("Description");

                    b.Property<string>("LogoUrl");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("SiteUrl");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("EDUCATIONAL_INSTITUTIONS");
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.Faculty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Acronym");

                    b.Property<long?>("BrandedDescriptionId");

                    b.Property<string>("Description");

                    b.Property<long>("EducationalInstitutionId");

                    b.Property<string>("LogoUrl");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("SiteUrl");

                    b.HasKey("Id");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("FACULTIES");
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.Geographic.Area", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("AREAS");
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.Partners", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EducationalInstitutionId");

                    b.Property<long>("EmployerId");

                    b.HasKey("Id");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("PARTNERS");
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.Synonyms.EducationalInstitutionSynonyms", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EducationalInstitutionId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("EDUCATIONAL_iNSTITUTION_SYNONYMS");
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.Synonyms.FacultySynonyms", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("FacultyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("FacultyId");

                    b.ToTable("FACULTY_SYNONYMS");
                });

            modelBuilder.Entity("Microsoft.EntityFrameworkCore.AutoHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Changed");

                    b.Property<DateTime>("Created");

                    b.Property<int>("Kind");

                    b.Property<string>("RowId")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("TableName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("AutoHistory");
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.EducationalInstitution", b =>
                {
                    b.HasOne("EducationalInstitutions.Db.Models.Geographic.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.Faculty", b =>
                {
                    b.HasOne("EducationalInstitutions.Db.Models.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Faculties")
                        .HasForeignKey("EducationalInstitutionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.Geographic.Area", b =>
                {
                    b.HasOne("EducationalInstitutions.Db.Models.Geographic.Area", "Parent")
                        .WithMany("Areas")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.Partners", b =>
                {
                    b.HasOne("EducationalInstitutions.Db.Models.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Partners")
                        .HasForeignKey("EducationalInstitutionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.Synonyms.EducationalInstitutionSynonyms", b =>
                {
                    b.HasOne("EducationalInstitutions.Db.Models.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Synonyms")
                        .HasForeignKey("EducationalInstitutionId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("EducationalInstitutions.Db.Models.Synonyms.FacultySynonyms", b =>
                {
                    b.HasOne("EducationalInstitutions.Db.Models.Faculty", "Faculty")
                        .WithMany("Synonyms")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
