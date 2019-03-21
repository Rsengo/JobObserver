using Login.Db.Constants;
using Login.Db.Models.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login.Db.Maps.Attributes
{
    internal class EducationalInstitutionManagerAttributesMap : 
        IEntityTypeConfiguration<EducationalInstitutionManagerAttributes>
    {
        public void Configure(EntityTypeBuilder<EducationalInstitutionManagerAttributes> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .Property(x => x.OrganizationId)
                .IsRequired();

            builder
                .Property(x => x.Position)
                .IsRequired();

            builder.ToTable(TableNames.EDUCATIONAL_INSTITUTION_MANAGER_ATTRIBUTES);
        }
    }
}
