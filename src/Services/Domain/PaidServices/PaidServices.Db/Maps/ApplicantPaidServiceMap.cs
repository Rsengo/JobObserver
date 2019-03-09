using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaidServices.Db.Constants;
using PaidServices.Db.Models;

namespace PaidServices.Db.Maps
{
    internal class ApplicantPaidServiceMap : 
        IEntityTypeConfiguration<ApplicantPaidService>
    {
        public void Configure(EntityTypeBuilder<ApplicantPaidService> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.Price).IsRequired();

            builder.ToTable(TableNames.APPLICANT_PAID_SERVICES);
        }
    }
}
