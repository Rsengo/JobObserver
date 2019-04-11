using CareerDays.Db.Constants;
using CareerDays.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerDays.Db.Maps
{
    public class CareerDayEducationalInstitutionMap : IEntityTypeConfiguration<CareerDayEducationalInstitution>
    {
        public void Configure(EntityTypeBuilder<CareerDayEducationalInstitution> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.CareerDay)
                .WithMany(x => x.EducationalInstitutions)
                .HasForeignKey(x => x.CareerDayId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.EducationalInstitution)
                .WithMany(x => x.CareerDays)
                .HasForeignKey(x => x.EducationalInstitutionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.CAREER_DAY_EDUCATIONAL_INSTITUTIONS);
        }
    }
}