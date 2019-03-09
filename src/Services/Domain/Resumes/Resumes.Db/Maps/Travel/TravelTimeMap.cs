using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Travel;

namespace Resumes.Db.Maps.Travel
{
    internal class TravelTimeMap : IEntityTypeConfiguration<TravelTime>
    {
        public void Configure(EntityTypeBuilder<TravelTime> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.TRAVEL_TIMES);
        }
    }
}
