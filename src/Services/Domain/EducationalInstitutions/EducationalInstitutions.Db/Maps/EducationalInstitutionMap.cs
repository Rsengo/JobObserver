using System;
using System.Collections.Generic;
using System.Text;
using EducationalInstitutions.Db.Constants;
using EducationalInstitutions.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalInstitutions.Db.Maps
{
    internal class EducationalInstitutionMap : 
        IEntityTypeConfiguration<EducationalInstitution>
    {
        public void Configure(EntityTypeBuilder<EducationalInstitution> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();

            builder
                .HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasMany(x => x.Synonyms)
                .WithOne(x => x.EducationalInstitution)
                .HasForeignKey(x => x.EducationalInstitutionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Partners)
                .WithOne(x => x.EducationalInstitution)
                .HasForeignKey(x => x.EducationalInstitutionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Faculties)
                .WithOne(x => x.EducationalInstitution)
                .HasForeignKey(x => x.EducationalInstitutionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.BrandedDescription)
                .WithOne()
                .HasForeignKey<EducationalInstitution>(x => x.BrandedDescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableNames.EDUCATIONAL_INSTITUTIONS);
        }
    }
}
