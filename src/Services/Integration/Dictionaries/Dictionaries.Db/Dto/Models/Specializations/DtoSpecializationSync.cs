using System;
using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;

namespace Dictionaries.Db.Dto.Models.Specializations
{ 
    public class DtoSpecializationSync : DtoDictionary
    {
        /// <summary>
        ///     Id Родителя
        /// </summary>
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние
        /// </summary>
        public virtual ICollection<DtoSpecializationSync> Specializations { get; set; }
    }
}
