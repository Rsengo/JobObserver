using System;
using System.Collections.Generic;
using System.Text;
using EducationalInstitutions.Db.Constants;
using EducationalInstitutions.Db.Models.Synonyms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalInstitutions.Db.Maps.Synonyms
{
    internal class FacultySynonymsMap : IEntityTypeConfiguration<FacultySynonyms>
    {
        public void Configure(EntityTypeBuilder<FacultySynonyms> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder
                .HasOne(x => x.Faculty)
                .WithMany(x => x.Synonyms)
                .HasForeignKey(x => x.FacultyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.FACULTY_SYNONYMS);
        }
    }
}
