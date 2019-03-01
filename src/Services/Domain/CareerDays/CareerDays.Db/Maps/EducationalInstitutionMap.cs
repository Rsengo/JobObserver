using System;
using System.Collections.Generic;
using System.Text;
using CareerDays.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerDays.Db.Maps
{
    internal class EducationalInstitutionMap: IEntityTypeConfiguration<EducationalInstitution>
    {
        public void Configure(EntityTypeBuilder<EducationalInstitution> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
