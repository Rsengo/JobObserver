using System;
using System.Collections.Generic;
using System.Text;
using Employers.Db.Constants;
using Employers.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employers.Db.Maps
{
    internal class EmployerMap : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder
                .HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Type)
                .WithMany()
                .HasForeignKey(x => x.TypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Partners)
                .WithOne()
                .HasForeignKey(x => x.EmployerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Departments)
                .WithOne()
                .HasForeignKey(x => x.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Synonyms)
                .WithOne()
                .HasForeignKey(x => x.EmployerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.BrandedDescription)
                .WithOne(x => x.Employer)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableNames.EMPLOYERS);
        }
    }
}
