using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Dictionaries.Dto.Models.Geographic.Metro
{
    /// <summary>
    ///     Ветка метро
    /// </summary>
    public class DtoLine : DtoEntity
    {
        /// <summary>
        /// Цвет в шестнадцетиричной системе
        /// </summary>
        [JsonProperty("hex_color")]
        public int HexColor { get; set; }
        /// <summary>
        /// Метро id
        /// </summary>
        [JsonProperty("metro_id")]
        public long MetroId { get; set; }
        /// <summary>
        /// Станции
        /// </summary>
        [JsonProperty("stations")]
        public ICollection<DtoStation> Stations { get; set; }
    }
}