using System;
using System.Collections.Generic;
using System.Text;
using EducationalInstitutions.Db.Constants;
using EducationalInstitutions.Db.Models;
using EducationalInstitutions.Db.Models.Synonyms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalInstitutions.Db.Maps.Synonyms
{
    internal class EducationalInstitutionSynonymsMap : 
        IEntityTypeConfiguration<EducationalInstitutionSynonyms>
    {
        public void Configure(EntityTypeBuilder<EducationalInstitutionSynonyms> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder
                .HasOne(x => x.EducationalInstitution)
                .WithMany(x => x.Synonyms)
                .HasForeignKey(x => x.EducationalInstitutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.EDUCATIONAL_INSTITUTION_SYNONYMS);
        }
    }
}
