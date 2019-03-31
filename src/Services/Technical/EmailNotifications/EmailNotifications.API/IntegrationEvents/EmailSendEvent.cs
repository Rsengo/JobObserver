using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EventBus.Events;
using EmailNotifications.Mailer;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EmailNotifications.API.IntegrationEvents
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
