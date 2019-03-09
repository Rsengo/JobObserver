using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Geographic.Metro;

namespace Vacancies.Db.Maps.Geographic.Metro
{
    internal class StationMap : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(128);
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Order).IsRequired();
            builder.HasOne(x => x.Line).WithMany(x => x.Stations).HasForeignKey(x => x.LineId)
                .OnDelete(DeleteBehavior.Restrict).IsRequired();

            builder.ToTable(TableNames.STATIONS);
        }
    }
}
