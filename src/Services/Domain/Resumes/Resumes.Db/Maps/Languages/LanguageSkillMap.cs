﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Languages;

namespace Resumes.Db.Maps.Languages
{
    internal class LanguageSkillMap : IEntityTypeConfiguration<LanguageSkill>
    {
        public void Configure(EntityTypeBuilder<LanguageSkill> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.Language)
                .WithMany()
                .HasForeignKey(x => x.LanguageId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Level)
                .WithMany()
                .HasForeignKey(x => x.LevelId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Resume)
                .WithMany(x => x.Languages)
                .HasForeignKey(x => x.ResumeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.LANGUAGE_SKILLS);
        }
    }
}
