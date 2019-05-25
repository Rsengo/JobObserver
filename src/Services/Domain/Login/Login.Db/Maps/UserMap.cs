using System;
using Login.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login.Db.Maps
{
    internal class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Ignore(x => x.FullName);

            builder.Property(x => x.BirthDate).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();

            builder
                .HasOne(x => x.Area)
                .WithMany()
                .HasForeignKey(x => x.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Gender)
                .WithMany()
                .HasForeignKey(x => x.GenderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.EducationalInstitutionManagerAttributes)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.EmployerManagerAttributes)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Contacts)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
