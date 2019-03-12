using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Employments;

namespace Resumes.Db.Maps.Employments
{
    public class ResumeEmploymentMap : 
        IEntityTypeConfiguration<ResumeEmployment>
    {
        public void Configure(EntityTypeBuilder<ResumeEmployment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.Employment)
                .WithMany()
                .HasForeignKey(x => x.EmploymentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Resume)
                .WithMany(x => x.Employments)
                .HasForeignKey(x => x.ResumeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.RESUME_EMPLOYMENTS);
        }
    }
}
