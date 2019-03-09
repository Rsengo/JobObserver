using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Experiences;

namespace Resumes.Db.Maps.Experiences
{
    internal class ExperienceMap : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.StartedAt).IsRequired();
            builder.Property(x => x.EndAt).IsRequired();
            builder.Property(x => x.Title).IsRequired();

            builder
                .HasOne(x => x.Specialization)
                .WithMany()
                .HasForeignKey(x => x.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Industry)
                .WithMany()
                .HasForeignKey(x => x.IndustryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableNames.EXPERIENCES);
        }
    }
}
