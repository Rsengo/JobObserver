using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Login.Db.Models.Geographic;
using Login.Db.Constants;

namespace Login.Db.Maps.Geographic
{
    internal class AreaMap : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasAlternateKey(x => x.Name);
            builder.Property(x => x.Name).IsRequired();

            builder
                .HasMany(x => x.Areas)
                .WithOne(x => x.Parent)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(x => x.Parent)
                .WithMany(x => x.Areas)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable(TableNames.AREAS);
        }
    }
}
