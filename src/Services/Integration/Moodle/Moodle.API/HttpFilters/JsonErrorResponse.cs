﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Moodle.API.HttpFilters
{
    public class JsonErrorResponse
    {
        [JsonProperty("messages")]
        public string[] Messages { get; set; }

        [JsonProperty("developer_message")]
        public object DeveloperMessage { get; set; }
    }
}
