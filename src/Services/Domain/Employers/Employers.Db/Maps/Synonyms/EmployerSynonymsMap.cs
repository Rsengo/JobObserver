using System;
using System.Collections.Generic;
using System.Text;
using Employers.Db.Constants;
using Employers.Db.Models.Synonyms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employers.Db.Maps.Synonyms
{
    internal class EmployerSynonymsMap : 
        IEntityTypeConfiguration<EmployerSynonyms>
    {
        public void Configure(EntityTypeBuilder<EmployerSynonyms> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Name).IsRequired();

            builder
                .HasOne(x => x.Employer)
                .WithMany(x => x.Synonyms)
                .HasForeignKey(x => x.EmployerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.EMPLOYER_SYNONYMS);
        }
    }
}
