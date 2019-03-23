using Login.Db.Constants;
using Login.Db.Models.Contacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login.Db.Maps.Contacts
{
    internal class PhoneMap : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .Property(x => x.Number)
                .IsRequired();

            builder
                .HasOne(x => x.Contact)
                .WithMany(x => x.Phones)
                .HasForeignKey(x => x.ContactId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.PHONES);
        }
    }
}
