using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Specializations;

namespace Vacancies.Db.Maps.Specializations
{
    internal class VacancySpecializationMap : 
        IEntityTypeConfiguration<VacancySpecialization>
    {
        public void Configure(EntityTypeBuilder<VacancySpecialization> builder)
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
                .HasOne(x => x.Vacancy)
                .WithMany(x => x.Specializations)
                .HasForeignKey(x => x.VacancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.VACANCY_SPECIALIZATIONS);
        }
    }
}
