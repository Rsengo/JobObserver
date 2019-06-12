using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Moodle.Integration.Models
{
    public class MoodleException: Exception
    {
        [JsonProperty("exception")]
        public string Exception { get; set; }

        [JsonProperty("errorcode")]
        public string ErrorCode { get; set; }

        [JsonProperty("message")]
        public override string Message { get; }
    }
}
