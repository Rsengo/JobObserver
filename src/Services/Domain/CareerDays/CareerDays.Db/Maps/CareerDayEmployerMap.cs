using CareerDays.Db.Constants;
using CareerDays.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerDays.Db.Maps
{
    internal class CareerDayEmployerMap : IEntityTypeConfiguration<CareerDayEmployer>
    {
        public void Configure(EntityTypeBuilder<CareerDayEmployer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.CareerDay)
                .WithMany(x => x.Employers)
                .HasForeignKey(x => x.CareerDayId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasOne(x => x.Employer)
                .WithMany(x => x.CareerDays)
                .HasForeignKey(x => x.EmployerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.ToTable(TableNames.CAREER_DAY_EMPLOYERS);
        }
    }
}
