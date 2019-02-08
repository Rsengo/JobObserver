using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Migrations.MongoDB
{
    public class MongoMigrationAttribute: Attribute
    {
        internal long Version { get; set; }

        public MongoMigrationAttribute(int day, int month, int year, int hours, int minutes, int seconds)
        {
            if (day > 31 ||
                month > 12 ||
                hours > 23 ||
                minutes > 59 ||
                seconds > 59)
            {
                throw new ArgumentException("Переданы невалидные аргументы для миграции");
            }

            var versionString = string.Concat(day, month, year, hours, minutes, seconds);
            var version = long.Parse(versionString);

            Version = version;
        }
    }
}
