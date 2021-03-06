﻿using EducationalInstitutions.Db.Constants;
using EducationalInstitutions.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationalInstitutions.Db.Maps
{
    public class BrandedTemplateMap : IEntityTypeConfiguration<BrandedTemplate>
    {
        public void Configure(EntityTypeBuilder<BrandedTemplate> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Text).IsRequired();

            builder.ToTable(TableNames.BRANDED_TEMPLATES);
        }
    }
}
