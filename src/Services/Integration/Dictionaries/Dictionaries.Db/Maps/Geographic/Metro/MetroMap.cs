using System;
using System.Collections.Generic;
using System.Text;
using Dictionaries.Db.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionaries.Db.Maps.Geographic.Metro
{
    internal class MetroMap : IEntityTypeConfiguration<Models.Geographic.Metro.Metro>
    {
        public void Configure(EntityTypeBuilder<Models.Geographic.Metro.Metro> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder
                .HasOne(x => x.Area)
                .WithOne(x => x.Metro)
                .HasForeignKey<Models.Geographic.Metro.Metro>(x => x.AreaId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            builder.HasMany(x => x.Lines).WithOne(x => x.Metro).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableNames.METRO);
        }
    }
}
