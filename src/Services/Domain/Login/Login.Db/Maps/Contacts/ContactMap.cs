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
                .HasOne(x => x.Phone)
                .WithOne()
                .HasForeignKey<Contact>(x => x.PhoneId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.AdditionalPhone)
                .WithOne()
                .HasForeignKey<Contact>(x => x.AdditionalPhoneId)
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
                .HasForeignKey(x => x.ContactId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableNames.CONTACTS);
        }
    }
}
