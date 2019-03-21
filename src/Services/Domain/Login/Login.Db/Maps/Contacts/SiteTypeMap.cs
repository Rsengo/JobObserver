using Login.Db.Constants;
using Login.Db.Models.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login.Db.Maps.Contacts
{
    internal class SiteTypeMap : IEntityTypeConfiguration<SiteType>
    {
        public void Configure(EntityTypeBuilder<SiteType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder.ToTable(TableNames.SITE_TYPES);
        }
    }
}
