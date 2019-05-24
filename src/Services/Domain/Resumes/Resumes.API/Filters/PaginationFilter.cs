using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Filters
{
    public class PaginationFilter
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }
    }
}
