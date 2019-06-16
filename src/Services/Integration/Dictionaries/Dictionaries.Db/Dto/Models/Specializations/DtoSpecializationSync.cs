using System;
using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Dictionaries.Db.Dto.Models.Specializations
{ 
    public class DtoSpecializationSync : DtoDictionary
    {
        /// <summary>
        ///     Id Родителя
        /// </summary>
        [JsonProperty("parent_id")]
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние
        /// </summary>
        [JsonProperty("specializations")]
        public virtual ICollection<DtoSpecializationSync> Specializations { get; set; }
    }
}
