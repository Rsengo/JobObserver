using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Geographic.Metro;

namespace Vacancies.Db.Maps.Geographic.Metro
{
    internal class LineMap : IEntityTypeConfiguration<Line>
    {
        public void Configure(EntityTypeBuilder<Line> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.HexColor).IsRequired();
            builder.HasOne(x => x.Metro).WithMany(x => x.Lines).HasForeignKey(x => x.MetroId)
                .OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasMany(x => x.Stations).WithOne(x => x.Line).OnDelete(DeleteBehavior.Cascade).IsRequired();

            builder.ToTable(TableNames.LINES);
        }
    }
}
