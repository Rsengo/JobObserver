using System;

namespace BuildingBlocks.EntityFramework.Models
{
    /// <summary>
    ///     Базовый словарь
    /// </summary>
    public abstract class RelationalDictionary : RelationalEntity
    {
        public virtual string Name { get; set; }
    }
}