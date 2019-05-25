using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace CareerDays.Db.Dto.Models
{ 
    /// <summary>
    ///     Брендированный шаблон
    /// </summary>
    public class DtoBrandedTemplate : DtoEntity
    {
        /// <summary>
        ///     Название.
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; set; }

        /// <summary>
        ///     HTML шаблон
        /// </summary>
        [JsonProperty("text")]
        public virtual string Text { get; set; }

        [JsonProperty("career_day_id")]
        public virtual long CareerDayId { get; set; } 
    }
}