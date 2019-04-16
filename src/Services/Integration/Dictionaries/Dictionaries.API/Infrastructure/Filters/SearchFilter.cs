using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dictionaries.API.Infrastructure.Filters
{
    public class SearchFilter
    {
        [JsonProperty("template")]
        public string Template { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("offset")]
        public int? Offset { get; set; }

        [JsonProperty("case_sensitive")]
        public bool CaseSensitive { get; set; }
    }
}
