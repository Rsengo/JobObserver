using BuildingBlocks.EventBus.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notifications.EventBus.Events
{
    public class MoodleEmployerRegisteredEvent: IntegrationEvent
    {
        [JsonProperty]
        public string Username { get; set; }

        [JsonProperty]
        public string Password { get; set; }

        [JsonProperty]
        public string Email { get; set; }

        public MoodleEmployerRegisteredEvent(
            string username, 
            string password, 
            string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
