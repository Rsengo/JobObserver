using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notifications.EventBus.Models
{
    public class DtoUser
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
