using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Specializations;

namespace Resumes.Db.Maps.Specializations
{
    public class ResumeSpecializationMap : 
        IEntityTypeConfiguration<ResumeSpecialization>
    {
        public void Configure(EntityTypeBuilder<ResumeSpecialization> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.Specialization)
                .WithMany()
                .HasForeignKey(x => x.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Resume)
                .WithMany(x => x.Specializations)
                .HasForeignKey(x => x.ResumeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.RESUME_SPECIALIZATIONS);
        }
    }
}
