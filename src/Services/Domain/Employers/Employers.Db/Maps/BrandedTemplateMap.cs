using Employers.Db.Constants;
using Employers.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employers.Db.Maps
{
    public class BrandedTemplateMap : IEntityTypeConfiguration<BrandedTemplate>
    {
        public void Configure(EntityTypeBuilder<BrandedTemplate> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Text).IsRequired();

            builder
                .HasOne(x => x.Employer)
                .WithOne()
                .HasForeignKey<BrandedTemplate>(x => x.EmployerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.BRANDED_TEMPLATES);
        }
    }
}
