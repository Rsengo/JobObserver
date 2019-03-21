using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Login.Dto.Models.Contacts
{
    /// <summary>
    ///     Сайт (соцсеть, месседжер)
    /// </summary>
    public class DtoSite : DtoDictionary
    {
        /// <summary>
        ///     Тип
        /// </summary>
        [JsonProperty("type")]
        public virtual DtoSiteType Type { get; set; }

        /// <summary>
        ///     Id Типа
        /// </summary>
        [JsonProperty("type_id")]
        public virtual long? TypeId { get; set; }

        /// <summary>
        ///     Значение (ссылка)
        /// </summary>
        [JsonProperty("value")]
        public virtual string Value { get; set; }

        /// <summary>
        ///     Является ли предпочтительным
        /// </summary>
        [JsonProperty("is_prefered")]
        public virtual bool IsPreferred { get; set; }

        [JsonProperty("contact_id")]
        public virtual long ContactId { get; set; }
    }
}