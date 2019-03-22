using System.ComponentModel.DataAnnotations.Schema;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Login.Dto.Models.Contacts
{
    /// <summary>
    ///     Телефон
    /// </summary>
    public class DtoPhone : DtoDictionary
    {
        /// <summary>
        ///     Номер
        /// </summary>
        [JsonProperty("number")]
        public virtual string Number { get; set; }

        /// <summary>
        ///     Комметарий
        /// </summary>
        [JsonProperty("comment")]
        public virtual string Comment { get; set; }
    }
}