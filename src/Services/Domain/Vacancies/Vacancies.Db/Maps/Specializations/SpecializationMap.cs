using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Constants;
using Vacancies.Db.Models.Specializations;

namespace Vacancies.Db.Maps.Specializations
{
    internal class SpecializationMap : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            builder
                .HasMany(x => x.Specializations)
                .WithOne(x => x.Parent)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Parent)
                .WithMany(x => x.Specializations)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.ToTable(TableNames.SPECIALIZATIONS);
        }
    }
}
