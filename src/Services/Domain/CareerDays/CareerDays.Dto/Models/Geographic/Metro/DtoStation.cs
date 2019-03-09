using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace CareerDays.Dto.Models.Geographic.Metro
{
    /// <summary>
    ///     Станция
    /// </summary>
    public class DtoStation : DtoEntity
    {
        /// <summary>
        /// Ширина (географически)
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Долгота (географически)
        /// </summary>
        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        /// <summary>
        /// Номер
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; set; }

        /// <summary>
        /// Ветка id
        /// </summary>
        [JsonProperty("line_id")]
        public long LineId { get; set; }

        /// <summary>
        /// Ветка.
        /// </summary>
        [JsonProperty("line")]
        public DtoLine Line { get; set; }
    }
}