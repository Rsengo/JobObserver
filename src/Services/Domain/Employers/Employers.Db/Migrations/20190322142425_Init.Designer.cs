﻿// <auto-generated />
using System;
using Employers.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Employers.Db.Migrations
{
    [DbContext(typeof(EmployersDbContext))]
    [Migration("20190322142425_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Employers.Db.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("OrganizationId");

                    b.Property<long?>("OrganizationId1");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("OrganizationId1");

                    b.ToTable("DEPARTMENTS");
                });

            modelBuilder.Entity("Employers.Db.Models.Employer", b =>
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

                    b.Property<long?>("TypeId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("AreaId");

                    b.HasIndex("TypeId");

                    b.ToTable("EMPLOYERS");
                });

            modelBuilder.Entity("Employers.Db.Models.EmployerType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("EMPLOYER_TYPES");
                });

            modelBuilder.Entity("Employers.Db.Models.Geographic.Area", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("ParentId");

                    b.ToTable("AREAS");
                });

            modelBuilder.Entity("Employers.Db.Models.Partners", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EducationalInstitutionId");

                    b.Property<long>("EmployerId");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.ToTable("PARTNERS");
                });

            modelBuilder.Entity("Employers.Db.Models.Synonyms.EmployerSynonyms", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("EmployerId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("EmployerId");

                    b.ToTable("EMPLOYER_SYNONYMS");
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

            modelBuilder.Entity("Employers.Db.Models.Department", b =>
                {
                    b.HasOne("Employers.Db.Models.Employer")
                        .WithMany("Departments")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Employers.Db.Models.Employer", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId1");
                });

            modelBuilder.Entity("Employers.Db.Models.Employer", b =>
                {
                    b.HasOne("Employers.Db.Models.Geographic.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Employers.Db.Models.EmployerType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Employers.Db.Models.Geographic.Area", b =>
                {
                    b.HasOne("Employers.Db.Models.Geographic.Area", "Parent")
                        .WithMany("Areas")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Employers.Db.Models.Partners", b =>
                {
                    b.HasOne("Employers.Db.Models.Employer", "Employer")
                        .WithMany("Partners")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Employers.Db.Models.Synonyms.EmployerSynonyms", b =>
                {
                    b.HasOne("Employers.Db.Models.Employer", "Employer")
                        .WithMany("Synonyms")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
