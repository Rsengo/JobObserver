using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.MongoDB.Migration
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MongoMigrationAttribute: Attribute
    {
        public string Version { get; }

        public string Description { get; }

        public MongoMigrationAttribute(
            int day, int month, int year, 
            int hours, int minutes, int seconds,
            string description)
        {
            if (day > 31 ||
                month > 12 ||
                hours > 23 ||
                minutes > 59 ||
                seconds > 59)
            {
                throw new ArgumentException("Переданы невалидные аргументы для миграции");
            }

            var dayStr = day.ToString().PadLeft(2, '0');
            var monthStr = month.ToString().PadLeft(2, '0');
            var yearStr = year.ToString();
            var hourStr = hours.ToString().PadLeft(2, '0');
            var minuteStr = minutes.ToString().PadLeft(2, '0');
            var secondStr = seconds.ToString().PadLeft(2, '0');

            Version = string.Concat(yearStr, monthStr, dayStr, hourStr, minuteStr, secondStr);
            Description = description;
        }
    }
}
