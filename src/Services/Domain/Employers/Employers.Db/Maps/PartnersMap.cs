using System;
using System.Collections.Generic;
using System.Text;
using Employers.Db.Constants;
using Employers.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employers.Db.Maps
{
    internal class PartnersMap : IEntityTypeConfiguration<Partners>
    {
        public void Configure(EntityTypeBuilder<Partners> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.EducationalInstitutionId).IsRequired();

            builder
                .HasOne(x => x.Employer)
                .WithMany(x => x.Partners)
                .HasForeignKey(x => x.EmployerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.PARTNERS);
        }
    }
}
