using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Skills;

namespace Vacancies.Db.Maps.Skills
{
    public class VacancySkillMap : 
        IEntityTypeConfiguration<VacancySkill>
    {
        public void Configure(EntityTypeBuilder<VacancySkill> builder)
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
                .HasOne(x => x.Vacancy)
                .WithMany(x => x.KeySkills)
                .HasForeignKey(x => x.VacancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.VACANCY_SKILLS);
        }
    }
}
