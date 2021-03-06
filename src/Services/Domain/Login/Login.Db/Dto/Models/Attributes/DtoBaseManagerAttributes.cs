﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;

namespace Login.Db.Dto.Models.Attributes
{
    public abstract class DtoBaseManagerAttributes : DtoDictionary
    {
        /// <summary>
        ///     Должность
        /// </summary>
        [JsonProperty("position")]
        public virtual string Position { get; set; }

        /// <summary>
        ///     Id Организации
        /// </summary>
        [JsonProperty("organization_id")]
        public virtual long OrganizationId { get; set; }

        [JsonProperty("user_id")]
        public virtual string UserId { get; set; }
    }
}
