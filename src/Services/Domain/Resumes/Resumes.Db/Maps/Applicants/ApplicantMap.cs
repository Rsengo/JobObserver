using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Applicants;

namespace Resumes.Db.Maps.Applicants
{
    internal class ApplicantMap : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.Email).IsRequired();

            builder
                .HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Gender)
                .WithMany()
                .HasForeignKey(x => x.GenderId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasMany(x => x.Resumes)
                .WithOne(x => x.Applicant)
                .HasForeignKey(x => x.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(x => x.FullName);

            builder.ToTable(TableNames.APPLICANTS);
        }
    }
}
