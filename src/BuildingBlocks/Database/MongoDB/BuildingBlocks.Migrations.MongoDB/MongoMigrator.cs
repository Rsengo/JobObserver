using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Migrations.MongoDB
{
    public sealed class MongoMigrator
    {
        /// <summary>
        /// Инстанс
        /// </summary>
        private static MongoMigrator _instance;

        /// <summary>
        /// Локкер
        /// </summary>
        private static readonly object _syncRoot = new object();

        /// <summary>
        /// Приватный конструктор
        /// </summary>
        private MongoMigrator() { }

        /// <summary>
        /// Получение инстанса
        /// </summary>
        public static MongoMigrator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new MongoMigrator();
                    }
                }
                return _instance;
            }
        }

        public void MigrateUp()
        {

        }

        public void MigrateDown()
        {

        }
    }
}
