using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Educations;

namespace Resumes.Db.Maps.Educations
{
    internal class EducationSpecializationMap : 
        IEntityTypeConfiguration<EducationSpecialization>
    {
        public void Configure(EntityTypeBuilder<EducationSpecialization> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.Education)
                .WithMany(x => x.Specializations)
                .HasForeignKey(x => x.EducationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Specialization)
                .WithMany()
                .HasForeignKey(x => x.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.EDUCATION_SPECIALIZATIONS);
        }
    }
}
