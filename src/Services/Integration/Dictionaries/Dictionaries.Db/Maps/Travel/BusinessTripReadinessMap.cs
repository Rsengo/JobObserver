﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dictionaries.Db.Constants;
using Dictionaries.Db.Models.Travel;

namespace Dictionaries.Db.Maps.Travel
{
    internal class BusinessTripReadinessMap : 
        IEntityTypeConfiguration<BusinessTripReadiness>
    {
        public void Configure(EntityTypeBuilder<BusinessTripReadiness> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.BUSINESS_TRIP_READINESS);
        }
    }
}
