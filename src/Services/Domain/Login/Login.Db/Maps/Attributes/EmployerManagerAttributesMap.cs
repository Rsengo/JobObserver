using Login.Db.Constants;
using Login.Db.Models.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Login.Db.Maps.Attributes
{
    internal class EmployerManagerAttributesMap : 
        IEntityTypeConfiguration<EmployerManagerAttributes>
    {
        public void Configure(EntityTypeBuilder<EmployerManagerAttributes> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .Property(x => x.OrganizationId)
                .IsRequired();

            builder
                .Property(x => x.Position)
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithOne(x => x.EmployerManagerAttributes)
                .HasForeignKey<EmployerManagerAttributes>(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.EMPLOYER_MANAGER_ATTRIBUTES);
        }
    }
}
