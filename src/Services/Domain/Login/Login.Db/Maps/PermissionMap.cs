using System;
using System.Collections.Generic;
using System.Text;
using Login.Db.Constants;
using Login.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login.Db.Maps
{
    internal class PermissionMap: IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasAlternateKey(x => new {x.Type, x.Value});

            builder.ToTable(TableNames.PERMISSIONS);
        }
    }
}
