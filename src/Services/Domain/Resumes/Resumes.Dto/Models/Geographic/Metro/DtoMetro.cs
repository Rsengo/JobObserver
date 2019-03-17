using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Resumes.Dto.Models.Geographic.Metro
{
    /// <summary>
    ///     Метро
    /// </summary>
    public class DtoMetro : DtoEntity
    {
        /// <summary>
        /// Id города
        /// </summary>
        [JsonProperty("area_id")]
        public long AreaId { get; set; }
    }
}