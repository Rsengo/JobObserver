using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Languages;

namespace Resumes.Db.Maps.Languages
{
    internal class LanguageLevelMap : IEntityTypeConfiguration<LanguageLevel>
    {
        public void Configure(EntityTypeBuilder<LanguageLevel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.LANGUAGE_LEVELS);
        }
    }
}
