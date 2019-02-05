using System;

namespace BuildingBlocks.Database.Entity
{
    public interface IDictionaryEntity
    {
        /// <summary>
        ///     Название
        /// </summary>
       string Name { get; set; }

        /// <summary>
        ///     GUID для синхронизации данных.
        /// </summary>
        Guid GlobalId { get; set; }
    }
}
