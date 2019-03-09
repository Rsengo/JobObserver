using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaidServices.Db.Constants;
using PaidServices.Db.Models;

namespace PaidServices.Db.Maps
{
    internal class EducationalInstitutionPaidServiceMap :
        IEntityTypeConfiguration<EducationalInstitutionPaidService>
    {
        public void Configure(EntityTypeBuilder<EducationalInstitutionPaidService> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.ToTable(TableNames.EDUCATIONAL_INSTITUTIONS_PAID_SERVICES);
        }
    }
}
