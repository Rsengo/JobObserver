using System;
using System.Collections.Generic;
using System.Text;
using Dictionaries.Db.Constants;
using Dictionaries.Db.Models.Statuses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionaries.Db.Maps.Statuses
{
    internal class ResumeStatusMap : IEntityTypeConfiguration<ResumeStatus>
    {
        public void Configure(EntityTypeBuilder<ResumeStatus> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();

            builder.HasAlternateKey(x => x.Name);

            builder.ToTable(TableNames.RESUME_STATUSES);
        }
    }
}
