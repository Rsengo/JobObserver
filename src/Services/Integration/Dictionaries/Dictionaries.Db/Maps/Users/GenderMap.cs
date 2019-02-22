using System;
using System.Collections.Generic;
using System.Text;
using Dictionaries.Db.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionaries.Db.Maps.Users
{
    internal class GenderMap : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            builder.HasAlternateKey(x => x.Name);

            builder.ToTable("GENDERS");
        }
    }
}
