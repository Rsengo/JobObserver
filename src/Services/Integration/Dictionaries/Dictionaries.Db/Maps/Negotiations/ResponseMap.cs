using System;
using System.Collections.Generic;
using System.Text;
using Dictionaries.Db.Models.Negotiations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionaries.Db.Maps.Negotiations
{
    internal class ResponseMap : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            builder.HasAlternateKey(x => x.Name);

            builder.ToTable("NEGOTIATIONS");
        }
    }
}
