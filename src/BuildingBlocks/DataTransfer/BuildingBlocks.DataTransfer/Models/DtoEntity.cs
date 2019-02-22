using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.DataTransfer.Models
{
    public abstract class DtoEntity
    {
        [JsonProperty("id")]
        public virtual long Id { get; set; }
    }
}
