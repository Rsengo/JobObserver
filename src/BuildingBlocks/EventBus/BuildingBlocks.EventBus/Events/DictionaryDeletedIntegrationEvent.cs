using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BuildingBlocks.EventBus.Events
{
    public class DictionaryDeletedIntegrationEvent : IntegrationEvent
    {
        [JsonProperty("ids")]
        public IEnumerable<long> Ids { get; set; }

        public DictionaryDeletedIntegrationEvent(IEnumerable<long> ids)
        {
            Ids = ids;
        }
    }
}