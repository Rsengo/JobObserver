using System.Collections.Generic;
using BuildingBlocks.EventBus.Events;
using Newtonsoft.Json;

namespace BuildingBlocks.EventBus.Synchronization.Events
{
    public class DictionaryChangedIntegrationEvent<TEntity> : IntegrationEvent
        where TEntity : class, new()
    {
        [JsonProperty("entities")]
        public IEnumerable<TEntity> Entities { get; set; }

        public DictionaryChangedIntegrationEvent(IEnumerable<TEntity> entities)
        {
            Entities = entities;
        }

        public DictionaryChangedIntegrationEvent() { }
    }
}