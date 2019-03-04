using System.Collections.Generic;
using BuildingBlocks.EntityFramework.Models;

namespace Login.Db.Models.Geographic
{
    /// <summary>
    ///     Город/страна
    /// </summary>
    public class Area : RelationalEntity
    {
        /// <summary>
        ///     Название
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     Родитель
        /// </summary>
        public virtual Area Parent { get; set; }

        /// <summary>
        ///     Id Родителя
        /// </summary>
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние
        /// </summary>
        public virtual ICollection<Area> Areas { get; set; }
    }
}