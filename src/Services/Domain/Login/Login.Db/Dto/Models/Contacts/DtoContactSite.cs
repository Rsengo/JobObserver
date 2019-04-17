using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using BuildingBlocks.DataTransfer.Models;

namespace Login.Db.Dto.Models.Contacts
{
    public class DtoContactSite : DtoEntity
    {
        [JsonProperty("site")]
        public virtual DtoSite Site { get; set; }

        [JsonProperty("site_id")]
        public virtual long SiteId { get; set; }

        [JsonProperty("contact_id")]
        public virtual long ContactId { get; set; }
    }
}
