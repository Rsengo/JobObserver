using System;
using System.Collections.Generic;
using System.Text;
using EducationalInstitutions.Db.Constants;
using EducationalInstitutions.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalInstitutions.Db.Maps
{
    internal class PartnersMap : IEntityTypeConfiguration<Partners>
    {
        public void Configure(EntityTypeBuilder<Partners> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.EmployerId).IsRequired();

            builder
                .HasOne(x => x.EducationalInstitution)
                .WithMany(x => x.Partners)
                .HasForeignKey(x => x.EducationalInstitutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.PARTNERS);
        }
    }
}
