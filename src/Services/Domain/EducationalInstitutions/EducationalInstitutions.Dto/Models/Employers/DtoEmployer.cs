using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace EducationalInstitutions.Dto.Models.Employers
{
    public class DtoEmployer : DtoDictionary
    {
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
        ///     Сокращение от названия
        /// </summary>
        [JsonProperty("acronym")]
        public virtual string Acronym { get; set; }
    }
}
