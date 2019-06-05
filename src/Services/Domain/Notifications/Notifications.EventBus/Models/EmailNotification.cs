using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Notifications.EventBus.Models
{
    public class EmailNotification
    {
        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("theme")]
        public string Theme { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
