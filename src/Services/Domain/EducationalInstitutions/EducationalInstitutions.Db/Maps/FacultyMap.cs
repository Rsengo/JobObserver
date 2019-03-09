using System;
using System.Collections.Generic;
using System.Text;
using EducationalInstitutions.Db.Constants;
using EducationalInstitutions.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalInstitutions.Db.Maps
{
    internal class FacultyMap : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();

            builder
                .HasOne(x => x.EducationalInstitution)
                .WithMany(x => x.Faculties)
                .HasForeignKey(x => x.EducationalInstitutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasMany(x => x.Synonyms)
                .WithOne(x => x.Faculty)
                .HasForeignKey(x => x.FacultyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableNames.FACULTIES);
        }
    }
}
