using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Travel.Relocation;

namespace Resumes.Db.Maps.Travel.Relocation
{
    internal class RelocationPossibilityMap : 
        IEntityTypeConfiguration<RelocationPossibility>
    {
        public void Configure(EntityTypeBuilder<RelocationPossibility> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.RelocationType)
                .WithMany()
                .HasForeignKey(x => x.RelocationTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.RELOCATION_POSSIBILITIES);
        }
    }
}
