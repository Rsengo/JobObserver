using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Driving;

namespace Vacancies.Db.Maps.Driving
{
    public class VacancyDrivingLicenseTypeMap : 
        IEntityTypeConfiguration<VacancyDrivingLicenseType>
    {
        public void Configure(EntityTypeBuilder<VacancyDrivingLicenseType> builder)
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
                .HasOne(x => x.Vacancy)
                .WithMany(x => x.DrivingLicenseTypes)
                .HasForeignKey(x => x.VacancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.VACANCY_DRIVING_LICENSE_TYPES);
        }
    }
}
