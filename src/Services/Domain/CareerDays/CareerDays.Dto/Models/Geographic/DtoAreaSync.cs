using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CareerDays.Dto.Models.Geographic
{
    public class DtoAreaSync : DtoDictionary
    {
        /// <summary>
        ///     Id Родителя
        /// </summary>
        [JsonProperty("parent_id")]
        public virtual long? ParentId { get; set; }

        /// <summary>
        ///     Дочерние
        /// </summary>
        [JsonProperty("areas")]
        public virtual ICollection<DtoAreaSync> Areas { get; set; }
    }
}
