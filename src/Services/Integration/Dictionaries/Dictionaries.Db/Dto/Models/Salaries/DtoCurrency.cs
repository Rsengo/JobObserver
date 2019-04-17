using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Dictionaries.Db.Dto.Models.Salaries
{
    /// <summary>
    ///     Валюта
    /// </summary>
    public class DtoCurrency : DtoDictionary
    {
        /// <summary>
        ///     Аббревиатура
        /// </summary>
        [JsonProperty("abbr")]
        public virtual string Abbr { get; set; }

        /// <summary>
        ///     Кодовое название
        /// </summary>
        [JsonProperty("code")]
        public virtual string Code { get; set; }
    }
}