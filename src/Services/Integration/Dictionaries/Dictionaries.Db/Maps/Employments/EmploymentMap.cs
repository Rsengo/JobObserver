using System;
using System.Collections.Generic;
using System.Text;
using Dictionaries.Db.Models.Employments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionaries.Db.Maps.Employments
{
    internal class EmploymentMap : IEntityTypeConfiguration<Employment>
    {
        public void Configure(EntityTypeBuilder<Employment> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            builder.HasAlternateKey(x => x.Name);

            builder.ToTable("EMPLOYMENTS");
        }
    }
}
