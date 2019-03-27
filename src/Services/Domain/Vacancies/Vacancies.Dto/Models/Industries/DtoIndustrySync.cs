using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;

namespace Vacancies.Dto.Models.Industries
{
    public class DtoIndustrySync : DtoDictionary
    {
        /// <summary>
        ///     Id Родителя
        /// </summary>
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние
        /// </summary>
        public virtual ICollection<DtoIndustrySync> Industries { get; set; }
    }
}
