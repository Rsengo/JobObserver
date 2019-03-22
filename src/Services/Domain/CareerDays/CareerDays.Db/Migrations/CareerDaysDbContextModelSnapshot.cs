﻿// <auto-generated />
using System;
using CareerDays.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CareerDays.Db.Migrations
{
    [DbContext(typeof(CareerDaysDbContext))]
    partial class CareerDaysDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CareerDays.Db.Models.CareerDay", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AddressId");

                    b.Property<long?>("BrandedDescriptionId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<long?>("EducationalInstitutionId");

                    b.Property<long>("EmployerId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("StartsAt");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("EducationalInstitutionId");

                    b.HasIndex("EmployerId");

                    b.ToTable("CAREER_DAYS");
                });

            modelBuilder.Entity("CareerDays.Db.Models.EducationalInstitution", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LogoUrl");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("SiteUrl");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("EDUCATIONAL_INSTITUTIONS");
                });

            modelBuilder.Entity("CareerDays.Db.Models.Employer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LogoUrl");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("SiteUrl");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("EMPLOYERS");
                });

            modelBuilder.Entity("CareerDays.Db.Models.Geographic.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AreaId");

                    b.Property<string>("Building")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<long?>("StationId");

                    b.Property<string>("Street")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("StationId");

                    b.ToTable("ADDRESSES");
                });

            modelBuilder.Entity("CareerDays.Db.Models.Geographic.Area", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("MetroId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("ParentId");

                    b.ToTable("AREAS");
                });

            modelBuilder.Entity("CareerDays.Db.Models.Geographic.Metro.Line", b =>
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

            modelBuilder.Entity("CareerDays.Db.Models.Geographic.Metro.Metro", b =>
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

            modelBuilder.Entity("CareerDays.Db.Models.Geographic.Metro.Station", b =>
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

            modelBuilder.Entity("CareerDays.Db.Models.CareerDay", b =>
                {
                    b.HasOne("CareerDays.Db.Models.Geographic.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CareerDays.Db.Models.EducationalInstitution", "EducationalInstitution")
                        .WithMany()
                        .HasForeignKey("EducationalInstitutionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CareerDays.Db.Models.Employer", "Employer")
                        .WithMany()
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CareerDays.Db.Models.Geographic.Address", b =>
                {
                    b.HasOne("CareerDays.Db.Models.Geographic.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CareerDays.Db.Models.Geographic.Metro.Station", "Station")
                        .WithMany()
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CareerDays.Db.Models.Geographic.Area", b =>
                {
                    b.HasOne("CareerDays.Db.Models.Geographic.Area", "Parent")
                        .WithMany("Areas")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CareerDays.Db.Models.Geographic.Metro.Line", b =>
                {
                    b.HasOne("CareerDays.Db.Models.Geographic.Metro.Metro", "Metro")
                        .WithMany("Lines")
                        .HasForeignKey("MetroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CareerDays.Db.Models.Geographic.Metro.Metro", b =>
                {
                    b.HasOne("CareerDays.Db.Models.Geographic.Area", "Area")
                        .WithOne("Metro")
                        .HasForeignKey("CareerDays.Db.Models.Geographic.Metro.Metro", "AreaId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CareerDays.Db.Models.Geographic.Metro.Station", b =>
                {
                    b.HasOne("CareerDays.Db.Models.Geographic.Metro.Line", "Line")
                        .WithMany("Stations")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
