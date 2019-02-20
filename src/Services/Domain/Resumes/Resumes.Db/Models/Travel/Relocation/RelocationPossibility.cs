using BuildingBlocks.EntityFramework.Models;

namespace Resumes.Db.Models.Travel.Relocation
{
    /// <summary>
    ///     Возможность переезда
    /// </summary>
    public class RelocationPossibility : RelationalEntity
    {
        /// <summary>
        ///     Тип переезда
        /// </summary>
        public virtual RelocationType RelocationType { get; set; }

        /// <summary>
        ///     Id Типа переезда
        /// </summary>
        public virtual long? RelocationTypeId { get; set; }

        /// <summary>
        ///     Id Города/страны
        /// </summary>
        public virtual long? AreaId { get; set; }
    }
}