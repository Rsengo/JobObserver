﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace CareerDays.Dto.Models
{
    public class DtoEducationalInstitution: DtoDictionary
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
    }
}
