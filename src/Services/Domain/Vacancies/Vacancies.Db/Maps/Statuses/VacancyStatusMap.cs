using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Statuses;

namespace Vacancies.Db.Maps.Statuses
{
    internal class VacancyStatusMap : IEntityTypeConfiguration<VacancyStatus>
    {
        public void Configure(EntityTypeBuilder<VacancyStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.VACANCY_STATUSES);
        }
    }
}
