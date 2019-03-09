using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Negotiations;

namespace Resumes.Db.Maps.Negotiations
{
    internal class ResumeNegotiationMap : 
        IEntityTypeConfiguration<ResumeNegotiation>
    {
        public void Configure(EntityTypeBuilder<ResumeNegotiation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CompanyId).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder
                .HasOne(x => x.Response)
                .WithMany()
                .HasForeignKey(x => x.ResponseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Resume)
                .WithMany(x => x.Negotiations)
                .HasForeignKey(x => x.ResumeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableNames.RESUME_NEGOTIATIONS);
        }
    }
}
