using System.Collections.Generic;
using BuildingBlocks.DataTransfer.Models;
using Employers.Dto.Models.Geographic;
using Newtonsoft.Json;

namespace Employers.Dto.Models
{
    /// <summary>
    ///     Работодатель
    /// </summary>
    public class DtoEmployer : DtoDictionary
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
        /// Снинонимичные названия
        /// </summary>
        [JsonProperty("synonyms")]
        public virtual ICollection<string> Synonyms { get; set; }

        /// <summary>
        ///     Id Брендированного описания
        /// </summary>
        [JsonProperty("branded_description_id")]
        public virtual long? BrandedDescriptionId { get; set; }

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

        /// <summary>
        ///     Отделения
        /// </summary>
        [JsonProperty("departments")]
        public virtual ICollection<DtoDepartment> Departments { get; set; }
    }
}