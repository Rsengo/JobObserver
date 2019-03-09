using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Driving;

namespace Resumes.Db.Maps.Driving
{
    internal class DrivingLicenseTypeMap : 
        IEntityTypeConfiguration<DrivingLicenseType>
    {
        public void Configure(EntityTypeBuilder<DrivingLicenseType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.DRIVING_LICENSE_TYPES);
        }
    }
}
