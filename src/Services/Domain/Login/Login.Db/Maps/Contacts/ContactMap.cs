using Login.Db.Constants;
using Login.Db.Models.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login.Db.Maps.Contacts
{
    internal class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasMany(x => x.Phones)
                .WithOne(x => x.Contact)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.Contacts)
                .HasForeignKey<Contact>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasMany(x => x.Sites)
                .WithOne(x => x.Contact)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableNames.CONTACTS);
        }
    }
}
