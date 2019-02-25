using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using CareerDays.Dto.Models.Geographic.Metro;
using Newtonsoft.Json;

namespace CareerDays.Dto.Models.Geographic
{
    public class DtoAddress : DtoEntity
    {
        /// <summary>
        /// Город id (избыточно)
        /// </summary>
        [JsonProperty("area")]
        public DtoArea Area { get; set; }

        /// <summary>
        /// Id Города
        /// </summary>
        [JsonProperty("area_id")]
        public long AreaId { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }

        /// <summary>
        /// Номер здания
        /// </summary>
        [JsonProperty("building")]
        public string Building { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

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
        /// Станция метро (избыточно)
        /// </summary>
        [JsonProperty("station")]
        public DtoStation Station { get; set; }

        /// <summary>
        /// Id Станции метро
        /// </summary>
        [JsonProperty("station_id")]
        public long? StationId { get; set; }
    }
}
