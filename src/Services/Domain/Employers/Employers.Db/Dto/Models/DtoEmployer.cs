using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Employers.Db.Dto.Models.Geographic;
using Newtonsoft.Json;

namespace Employers.Db.Dto.Models
{
    /// <summary>
    ///     Работодатель
    /// </summary>
    public class DtoEmployer : DtoDictionary
    {
        /// <summary>
        ///     Id Города
        /// </summary>
        public virtual long? AreaId { get; set; }

        public virtual DtoArea Area { get; set; }

        /// <summary>
        ///     Сокращение от названия
        /// </summary>
        [JsonProperty("acronym")]
        public virtual string Acronym { get; set; }

        /// <summary>
        ///     Описание
        /// </summary>
        [JsonProperty("description")]
        public virtual string Description { get; set; }

        /// <summary>
        ///     Id Брендированного описания
        /// </summary>
        [JsonProperty("branded_description")]
        public virtual DtoBrandedTemplate BrandedDescription { get; set; }

        /// <summary>
        ///     Логотип
        /// </summary>
        [JsonProperty("logo_url")]
        public virtual string LogoUrl { get; set; }

        /// <summary>
        ///     Сайт компании
        /// </summary>
        [JsonProperty("site_url")]
        public virtual string SiteUrl { get; set; }

        /// <summary>
        ///     Тип работодателя (Кадровое агентство, рекрутер, прямой работодатель и т.д.)
        /// </summary>
        [JsonProperty("type")]
        public virtual DtoEmployerType Type { get; set; }

        /// <summary>
        ///     Id Типа работодателя
        /// </summary>
        [JsonProperty("type_id")]
        public virtual long? TypeId { get; set; }
    }
}