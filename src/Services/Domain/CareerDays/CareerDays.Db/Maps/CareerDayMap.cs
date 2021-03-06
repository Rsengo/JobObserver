﻿using System;
using System.Collections.Generic;
using System.Text;
using CareerDays.Db.Constants;
using CareerDays.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CareerDays.Db.Maps
{
    internal class CareerDayMap : IEntityTypeConfiguration<CareerDay>
    {
        public void Configure(EntityTypeBuilder<CareerDay> builder)
        {
            //Установка первичного ключа
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.StartsAt).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasMany(x => x.Employers)
                .WithOne(x => x.CareerDay)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.EducationalInstitutions)
                .WithOne(x => x.CareerDay)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder
                .HasOne(x => x.BrandedDescription)
                .WithOne(x => x.CareerDay)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableNames.CAREER_DAYS);
        }
    }
}
