﻿// <auto-generated />
using System;
using Dictionaries.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dictionaries.Db.Migrations
{
    [DbContext(typeof(DictionariesDbContext))]
    [Migration("20190327161439_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dictionaries.Db.Models.Contacts.SiteType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("SITE_TYPES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Driving.DrivingLicenseType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("DRIVING_LICENSE_TYPES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Educations.EducationalLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("EDUCATIONAL_LEVELS");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Employer.EmployerType", b =>
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

            modelBuilder.Entity("Dictionaries.Db.Models.Employments.Employment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("EMPLOYMENTS");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Geographic.Area", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("MetroId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("AREAS");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Geographic.Metro.Line", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HexColor");

                    b.Property<long>("MetroId");

                    b.HasKey("Id");

                    b.HasIndex("MetroId");

                    b.ToTable("LINES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Geographic.Metro.Metro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AreaId");

                    b.HasKey("Id");

                    b.HasIndex("AreaId")
                        .IsUnique();

                    b.ToTable("METRO");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Geographic.Metro.Station", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Latitude");

                    b.Property<long>("LineId");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("LineId");

                    b.ToTable("STATIONS");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Industries.Industry", b =>
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

                    b.ToTable("INDUSTRIES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Languages.Language", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("LANGUAGES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Languages.LanguageLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("LANGUAGE_LEVELS");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Negotiations.Response", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("RESPONSES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Salaries.Currency", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbr");

                    b.Property<string>("Code");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("CURRENCIES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Schedules.Schedule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("SCHEDULES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Skills.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("SKILLS");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Specializations.Specialization", b =>
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

                    b.ToTable("SPECIALIZATIONS");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Statuses.ResumeStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("RESUME_STATUSES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Statuses.VacancyStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("VACANCY_STATUSES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Travel.BusinessTripReadiness", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("BUSINESS_TRIP_READINESS");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Travel.Relocation.RelocationType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("RELOCATION_TYPES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Travel.TravelTime", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("TRAVEL_TIMES");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Users.Gender", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("GENDERS");
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Geographic.Area", b =>
                {
                    b.HasOne("Dictionaries.Db.Models.Geographic.Area", "Parent")
                        .WithMany("Areas")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Geographic.Metro.Line", b =>
                {
                    b.HasOne("Dictionaries.Db.Models.Geographic.Metro.Metro", "Metro")
                        .WithMany("Lines")
                        .HasForeignKey("MetroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Geographic.Metro.Metro", b =>
                {
                    b.HasOne("Dictionaries.Db.Models.Geographic.Area", "Area")
                        .WithOne("Metro")
                        .HasForeignKey("Dictionaries.Db.Models.Geographic.Metro.Metro", "AreaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Geographic.Metro.Station", b =>
                {
                    b.HasOne("Dictionaries.Db.Models.Geographic.Metro.Line", "Line")
                        .WithMany("Stations")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Industries.Industry", b =>
                {
                    b.HasOne("Dictionaries.Db.Models.Industries.Industry", "Parent")
                        .WithMany("Industries")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Dictionaries.Db.Models.Specializations.Specialization", b =>
                {
                    b.HasOne("Dictionaries.Db.Models.Specializations.Specialization", "Parent")
                        .WithMany("Specializations")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
