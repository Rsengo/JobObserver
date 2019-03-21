using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Login.Db.Constants;
using Login.Db.Models.Genders;

namespace Login.Db.Maps.Genders
{
    internal class GenderMap : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.GENDERS);
        }
    }
}
