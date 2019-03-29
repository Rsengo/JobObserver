using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Login.Dto.Models
{
    public class DtoPermission : DtoEntity
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
