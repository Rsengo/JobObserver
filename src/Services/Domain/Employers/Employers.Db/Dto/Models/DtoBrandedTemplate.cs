using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Employers.Db.Dto.Models
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

        [JsonProperty("employer_id")]
        public virtual long? EmployerId { get; set; }
    }
}