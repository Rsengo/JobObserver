using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BuildingBlocks.DataTransfer.Models
{
    public abstract class DtoDictionary: DtoEntity
    {
        [JsonProperty("name")]
        public virtual string Name { get; set; }
    }
}
