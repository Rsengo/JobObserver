using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using BuildingBlocks.DataTransfer.Models;

namespace Dictionaries.Dto.Models.Industries
{
    /// <summary>
    ///     Сфера деятельности
    /// </summary>
    public class DtoIndustry : DtoDictionary
    {
        /// <summary>
        ///     Родитель.
        /// </summary>
        public virtual DtoIndustry Parent { get; set; }

        /// <summary>
        ///     Id родителя.
        /// </summary>
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние.
        /// </summary>
        public virtual ICollection<DtoIndustry> Industries { get; set; }
    }
}