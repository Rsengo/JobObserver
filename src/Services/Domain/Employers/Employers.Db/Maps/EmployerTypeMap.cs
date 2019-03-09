using System;
using System.Collections.Generic;
using System.Text;
using Employers.Db.Constants;
using Employers.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employers.Db.Maps
{
    internal class EmployerTypeMap : IEntityTypeConfiguration<EmployerType>
    {
        public void Configure(EntityTypeBuilder<EmployerType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.EMPLOYER_TYPES);
        }
    }
}
