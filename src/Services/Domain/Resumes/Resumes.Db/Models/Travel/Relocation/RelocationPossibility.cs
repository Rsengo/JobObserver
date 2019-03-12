using BuildingBlocks.EntityFramework.Models;
using Resumes.Db.Models.Geographic;

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
        public virtual long RelocationTypeId { get; set; }

        /// <summary>
        ///     Id Города/страны
        /// </summary>
        public virtual long AreaId { get; set; }

        public virtual Area Area { get; set; }

        public virtual Resume Resume { get; set; }

        public virtual long ResumeId { get; set; }
    }
}