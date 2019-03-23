using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Login.Dto.Models.Contacts
{
    /// <summary>
    ///     Контакты
    /// </summary>
    public class DtoContact : DtoDictionary
    {
        /// <summary>
        ///     Телефон
        /// </summary>
        [JsonProperty("phones")]
        public virtual ICollection<DtoPhone> Phone { get; set; }

        /// <summary>
        ///     Другие контакты
        /// </summary>
        [JsonProperty("sites")]
        public virtual ICollection<DtoSite> Sites { get; set; }
    }
}