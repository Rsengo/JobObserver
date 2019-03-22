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
        [JsonProperty("phone")]
        public virtual DtoPhone Phone { get; set; }

        /// <summary>
        ///     Id Телефона
        /// </summary>
        [JsonProperty("phone_id")]
        public virtual long PhoneId { get; set; }

        /// <summary>
        ///     Доп. телефон
        /// </summary>
        [JsonProperty("additional_phone")]
        public virtual DtoPhone AdditionalPhone { get; set; }

        /// <summary>
        ///     Id Доп. телефона
        /// </summary>
        [JsonProperty("additional_phone_id")]
        public virtual long? AdditionalPhoneId { get; set; }

        /// <summary>
        ///     Другие контакты
        /// </summary>
        [JsonProperty("sites")]
        public virtual ICollection<DtoSite> Sites { get; set; }
    }
}