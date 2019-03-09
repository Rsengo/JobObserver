﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Travel.Relocation;

namespace Resumes.Db.Maps.Travel.Relocation
{
    internal class RelocationTypeMap : IEntityTypeConfiguration<RelocationType>
    {
        public void Configure(EntityTypeBuilder<RelocationType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.RELOCATION_TYPES);
        }
    }
}
