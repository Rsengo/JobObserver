using CareerDays.Db.Constants;
using CareerDays.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerDays.Db.Maps
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
                .HasOne(x => x.CareerDay)
                .WithOne(x => x.BrandedDescription)
                .HasForeignKey<BrandedTemplate>(x => x.CareerDayId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.BRANDED_TEMPLATES);
        }
    }
}
