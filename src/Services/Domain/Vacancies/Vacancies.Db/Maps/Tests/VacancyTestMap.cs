using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Tests;

namespace Vacancies.Db.Maps.Tests
{
    internal class VacancyTestMap : IEntityTypeConfiguration<VacancyTest>
    {
        public void Configure(EntityTypeBuilder<VacancyTest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.TestId).IsRequired();

            builder
                .HasOne(x => x.Vacancy)
                .WithMany(x => x.Tests)
                .HasForeignKey(x => x.VacancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.VACANCY_TESTS);
        }
    }
}
