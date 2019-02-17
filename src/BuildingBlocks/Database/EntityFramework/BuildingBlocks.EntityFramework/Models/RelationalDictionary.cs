using System;
using BuildingBlocks.Database.Entity;

namespace BuildingBlocks.EntityFramework.Models
{
    /// <summary>
    ///     Базовый словарь
    /// </summary>
    public abstract class RelationalDictionary : RelationalEntity, IDictionaryEntity
    {
        /// <inheritdoc />
        public virtual string Name { get; set; }

        /// <inheritdoc />
        public virtual Guid GlobalId { get; set; }
    }
}