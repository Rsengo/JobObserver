using System;

namespace BuildingBlocks.Database.Entity
{
    public class DictionaryEntity<TEntityId> : BaseEntity<TEntityId> 
        where TEntityId : struct
    {
        /// <summary>
        ///     Название
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     GUID для синхронизации данных.
        /// </summary>
        public virtual Guid GlobalId { get; set; }
    }
}
