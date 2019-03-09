using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Industries;

namespace Vacancies.Db.Maps.Industries
{
    internal class IndustryMap : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder
                .HasMany(x => x.Industries)
                .WithOne(x => x.Parent)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.Parent)
                .WithMany(x => x.Industries)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableNames.INDUSTRIES);
        }
    }
}
