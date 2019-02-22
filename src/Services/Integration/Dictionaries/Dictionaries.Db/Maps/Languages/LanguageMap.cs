using System;
using System.Collections.Generic;
using System.Text;
using Dictionaries.Db.Models.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionaries.Db.Maps.Languages
{
    internal class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            builder.HasAlternateKey(x => x.Name);

            builder.ToTable("LANGUAGES");
        }
    }
}
