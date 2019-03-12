using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Schedules;

namespace Resumes.Db.Maps.Schedules
{
    public class ResumeScheduleMap : 
        IEntityTypeConfiguration<ResumeSchedule>
    {
        public void Configure(EntityTypeBuilder<ResumeSchedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.Schedule)
                .WithMany()
                .HasForeignKey(x => x.ScheduleId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Resume)
                .WithMany(x => x.Schedules)
                .HasForeignKey(x => x.ResumeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.RESUME_SCHEDULES);
        }
    }
}
