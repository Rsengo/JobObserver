using System;
using System.Collections.Generic;
using System.Text;
using Dictionaries.Db.Constants;
using Dictionaries.Db.Models.Industries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionaries.Db.Maps.Industries
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
