using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Driving;

namespace Resumes.Db.Maps.Driving
{
    internal class ResumeDrivingLicenseTypeMap : 
        IEntityTypeConfiguration<ResumeDrivingLicenseType>
    {
        public void Configure(EntityTypeBuilder<ResumeDrivingLicenseType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.DrivingLicenseType)
                .WithMany()
                .HasForeignKey(x => x.DrivingLicenseTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Resume)
                .WithMany(x => x.DriverLicenseTypes)
                .HasForeignKey(x => x.ResumeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.RESUME_DRIVING_LICENSE_TYPES);
        }
    }
}
