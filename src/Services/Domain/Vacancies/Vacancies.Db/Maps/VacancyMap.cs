using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models;

namespace Vacancies.Db.Maps
{
    internal class VacancyMap : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.AcceptHandicapped).IsRequired();
            builder.Property(x => x.AllowMessages).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.IsPremium).IsRequired();
            builder.Property(x => x.PublishedAt).IsRequired();
            builder.Property(x => x.RequiredVehicle).IsRequired();
            builder.Property(x => x.ResponseLetterRequired).IsRequired();
            builder.Property(x => x.ResponseNotification).IsRequired();
            builder.Property(x => x.Title).IsRequired();

            builder
                .HasOne(x => x.Department)
                .WithMany()
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Employer)
                .WithMany(x => x.Vacancies)
                .HasForeignKey(x => x.EmployerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Salary)
                .WithMany()
                .HasForeignKey(x => x.SalaryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Employment)
                .WithMany()
                .HasForeignKey(x => x.EmploymentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.VacancyStatus)
                .WithMany()
                .HasForeignKey(x => x.VacancyStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Schedule)
                .WithMany()
                .HasForeignKey(x => x.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.DriverLicenseTypes)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Negotiations)
                .WithOne(x => x.Vacancy)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Tests)
                .WithOne(x => x.Vacancy)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.KeySkills)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Languages)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableNames.VACANCIES);
        }
    }
}
