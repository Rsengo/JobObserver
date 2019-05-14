using Vacancies.Db.Constants;
using Vacancies.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vacancies.Db.Models.BrandedTemplates;

namespace Vacancies.Db.Maps.BrandedTemplates
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
                .HasOne(x => x.Vacancy)
                .WithOne(x => x.BrandedDescription)
                .HasForeignKey<BrandedTemplate>(x => x.VacancyId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.BRANDED_TEMPLATES);
        }
    }
}
