using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;

namespace Dictionaries.Db.Dto.Models.Specializations
{
    /// <summary>
    ///     Специализация
    /// </summary>
    public class DtoSpecialization : DtoDictionary
    {
        /// <summary>
        ///     Родитель.
        /// </summary>
        public virtual DtoSpecialization Parent { get; set; }

        /// <summary>
        ///     Id родителя.
        /// </summary>
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние.
        /// </summary>
        public virtual ICollection<DtoSpecialization> Specializations { get; set; }
    }
}