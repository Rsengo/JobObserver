using System;
using System.Collections.Generic;
using System.Text;
using CareerDays.Db.Maps;
using CareerDays.Db.Maps.Geographic;
using CareerDays.Db.Maps.Geographic.Metro;
using CareerDays.Db.Models;
using CareerDays.Db.Models.Geographic;
using CareerDays.Db.Models.Geographic.Metro;
using Microsoft.EntityFrameworkCore;

namespace CareerDays.Db
{
    public partial class CareerDaysDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CareerDayMap());
            builder.ApplyConfiguration(new LineMap());
            builder.ApplyConfiguration(new MetroMap());
            builder.ApplyConfiguration(new StationMap());
            builder.ApplyConfiguration(new AreaMap());
            builder.ApplyConfiguration(new AddressMap());

            base.OnModelCreating(builder);
        }

        public DbSet<CareerDay> CareerDays { get; set; }

        public DbSet<Line> Lines { get; set; }

        public DbSet<Metro> Metro { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}
