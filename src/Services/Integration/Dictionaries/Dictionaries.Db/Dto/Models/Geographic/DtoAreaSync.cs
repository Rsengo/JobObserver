using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;

namespace Dictionaries.Db.Dto.Models.Geographic
{
    public class DtoAreaSync : DtoDictionary
    {
        /// <summary>
        ///     Id Родителя
        /// </summary>
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние
        /// </summary>
        public virtual ICollection<DtoAreaSync> Areas { get; set; }
    }
}
