using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Moodle.Integration.Models
{
    public abstract class MoodleRequest
    {
        [JsonProperty("wstoken")]
        public string Token { get; set; }

        [JsonProperty("wsfunction")]
        public abstract string Function { get; }

        [JsonProperty("moodlewsrestformat")]
        public string RestFormat { get; set; }
    }
}
