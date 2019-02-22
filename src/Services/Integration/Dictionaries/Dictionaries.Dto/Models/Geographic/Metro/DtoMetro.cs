using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Dictionaries.Dto.Models.Geographic.Metro
{
    /// <summary>
    ///     Метро
    /// </summary>
    public class DtoMetro : DtoEntity
    {
        /// <summary>
        /// Город (избыточно)
        /// </summary>
        [JsonProperty("area")]
        public DtoArea Area { get; set; }
        /// <summary>
        /// Id города
        /// </summary>
        [JsonProperty("area_id")]
        public long AreaId { get; set; }
        /// <summary>
        /// Ветки
        /// </summary>
        [JsonProperty("lines")]
        public ICollection<DtoLine> Lines { get; set; }
    }
}