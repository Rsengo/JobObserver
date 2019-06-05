using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Notifications.EventBus.Models;

namespace Notifications.EventBus.Events
{
    public class EmailSendEvent : IntegrationEvent
    {
        [JsonProperty("message")]
        public EmailNotification Message;

        public EmailSendEvent(EmailNotification message)
        {
            Message = message;
        }
    }
}
