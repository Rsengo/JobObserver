using System;
using System.Collections.Generic;
using System.Text;
using CareerDays.Db.Constants;
using CareerDays.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerDays.Db.Maps
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

            builder.ToTable(TableNames.EMPLOYERS);
        }
    }
}
