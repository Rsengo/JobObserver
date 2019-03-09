using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Employers;

namespace Vacancies.Db.Maps.Employers
{
    internal class EmployerMap: IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            builder
                .HasMany(x => x.Vacancies)
                .WithOne(x => x.Employer)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.ToTable(TableNames.EMPLOYERS);
        }
    }
}
