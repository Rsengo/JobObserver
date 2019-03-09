using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Negotiations;

namespace Vacancies.Db.Maps.Negotiations
{
    internal class VacancyNegotiationMap : 
        IEntityTypeConfiguration<VacancyNegotiation>
    {
        public void Configure(EntityTypeBuilder<VacancyNegotiation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.ApplicantId).IsRequired();
            builder.Property(x => x.Date).IsRequired();

            builder
                .HasOne(x => x.Response)
                .WithMany()
                .HasForeignKey(x => x.ResponseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Vacancy)
                .WithMany(x => x.Negotiations)
                .HasForeignKey(x => x.VacancyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableNames.VACANCY_NEGOTIATIONS);
        }
    }
}
