using System.Collections.Generic;
using BuildingBlocks.EntityFramework.Models;

namespace Dictionaries.Db.Models.Geographic.Metro
{
    /// <summary>
    ///     Метро
    /// </summary>
    public class Metro : RelationalEntity
    {
        /// <summary>
        ///     Город
        /// </summary>
        public virtual Area Area { get; set; }

        /// <summary>
        ///     Id города
        /// </summary>
        public virtual long AreaId { get; set; }

        /// <summary>
        ///     Ветки
        /// </summary>
        public virtual ICollection<Line> Lines { get; set; }
    }
}