using System;
using System.Collections.Generic;
using System.Text;
using Dictionaries.Db.Models.Educations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionaries.Db.Maps.Educations
{
    internal class EducationalLevelMap : IEntityTypeConfiguration<EducationalLevel>
    {
        public void Configure(EntityTypeBuilder<EducationalLevel> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            builder.HasAlternateKey(x => x.Name);

            builder.ToTable("EDUCATIONAL_LEVELS");
        }
    }
}
