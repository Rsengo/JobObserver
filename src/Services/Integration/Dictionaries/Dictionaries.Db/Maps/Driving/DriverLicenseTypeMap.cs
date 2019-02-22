using System;
using System.Collections.Generic;
using System.Text;
using Dictionaries.Db.Models.Driving;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionaries.Db.Maps.Driving
{
    internal class DriverLicenseTypeMap : IEntityTypeConfiguration<DrivingLicenseType>
    {
        public void Configure(EntityTypeBuilder<DrivingLicenseType> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            builder.HasAlternateKey(x => x.Name);

            builder.ToTable("DRIVER_LICENSES");
        }
    }
}
