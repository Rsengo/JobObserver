using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Educations;

namespace Resumes.Db.Maps.Educations
{
    internal class EducationMap : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.AdmissionDate).IsRequired();
            builder.Property(x => x.FacultyId).IsRequired();

            builder
                .HasOne(x => x.EducationalLevel)
                .WithMany()
                .HasForeignKey(x => x.EducationalLevelId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasMany(x => x.Specializations)
                .WithOne(x => x.Education)
                .HasForeignKey(x => x.EducationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.EDUCATIONS);
        }
    }
}
