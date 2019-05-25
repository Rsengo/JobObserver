using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace EducationalInstitutions.Db.Dto.Models
{
    /// <summary>
    ///     Абстрактная организация
    /// </summary>
    public abstract class DtoBaseOrganization : DtoDictionary
    {
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
        [JsonProperty("branded_description_id")]
        public virtual long? BrandedDescriptionId { get; set; }

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
    }
}