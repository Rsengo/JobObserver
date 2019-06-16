using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Dictionaries.Db.Dto.Models.Industries
{
    public class DtoIndustrySync : DtoDictionary
    {
        /// <summary>
        ///     Id Родителя
        /// </summary>
        [JsonProperty("parent_id")]
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние
        /// </summary>
        [JsonProperty("industries")]
        public virtual ICollection<DtoIndustrySync> Industries { get; set; }
    }
}
