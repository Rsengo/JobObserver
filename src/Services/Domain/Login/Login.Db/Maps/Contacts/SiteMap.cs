using Login.Db.Constants;
using Login.Db.Models.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login.Db.Maps.Contacts
{
    internal class SiteMap : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .Property(x => x.IsPreferred)
                .IsRequired();

            builder
                .Property(x => x.Value)
                .IsRequired();

            builder
                .HasOne(x => x.Contact)
                .WithMany(x => x.Sites)
                .HasForeignKey(x => x.ContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Type)
                .WithMany()
                .HasForeignKey(x => x.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.SITES);
        }
    }
}
