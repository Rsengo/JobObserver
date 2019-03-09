using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Statuses;

namespace Resumes.Db.Maps.Statuses
{
    internal class ResumeStatusMap : IEntityTypeConfiguration<ResumeStatus>
    {
        public void Configure(EntityTypeBuilder<ResumeStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.RESUME_STATUSES);
        }
    }
}
