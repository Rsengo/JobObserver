using System;
using System.Collections.Generic;
using System.Text;
using CareerDays.Db.Constants;
using CareerDays.Db.Models.Geographic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerDays.Db.Maps.Geographic
{
    internal class AreaMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder
                .HasMany(x => x.Areas)
                .WithOne(x => x.Parent)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.Parent)
                .WithMany(x => x.Areas)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            builder.HasOne(x => x.Metro)
                .WithOne(x => x.Area)
                .HasForeignKey<Area>(x => x.MetroId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.ToTable(TableNames.AREAS);
        }
    }
}
