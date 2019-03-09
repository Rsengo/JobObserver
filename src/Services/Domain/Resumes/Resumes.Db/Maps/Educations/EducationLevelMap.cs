using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resumes.Db.Constants;
using Resumes.Db.Models.Educations;

namespace Resumes.Db.Maps.Educations
{
    internal class EducationLevelMap : 
        IEntityTypeConfiguration<EducationalLevel>
    {
        public void Configure(EntityTypeBuilder<EducationalLevel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.EDUCATIONAL_LEVELS);
        }
    }
}
