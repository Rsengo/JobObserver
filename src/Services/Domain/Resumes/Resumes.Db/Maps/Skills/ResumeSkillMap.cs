using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Skills;

namespace Resumes.Db.Maps.Skills
{
    public class ResumeSkillMap : IEntityTypeConfiguration<ResumeSkill>
    {
        public void Configure(EntityTypeBuilder<ResumeSkill> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.Skill)
                .WithMany()
                .HasForeignKey(x => x.SkillId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Resume)
                .WithMany(x => x.Skills)
                .HasForeignKey(x => x.ResumeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.RESUME_SKILLS);
        }
    }
}
