using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models;

namespace Resumes.Db.Maps
{
    internal class ResumeMap : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.IsPremium).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.UpdatedAt).IsRequired();

            builder
                .HasOne(x => x.Applicant)
                .WithMany(x => x.Resumes)
                .HasForeignKey(x => x.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasOne(x => x.BusinessTripReadiness)
                .WithMany()
                .HasForeignKey(x => x.BusinessTripReadinessId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.MetroStation)
                .WithMany()
                .HasForeignKey(x => x.MetroStationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Salary)
                .WithMany()
                .HasForeignKey(x => x.SalaryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.TravelTime)
                .WithMany()
                .HasForeignKey(x => x.TravelTimeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.ResumeLocale)
                .WithMany()
                .HasForeignKey(x => x.ResumeLocaleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.ResumeStatus)
                .WithMany()
                .HasForeignKey(x => x.ResumeStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Languages)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Citizenship)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Certificates)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.DriverLicenseTypes)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Education)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Employments)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Experience)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Negotiations)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.RelocationPossibility)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Schedules)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Skills)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.WorkTicket)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Specializations)
                .WithOne(x => x.Resume)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableNames.RESUMES);
        }
    }
}
