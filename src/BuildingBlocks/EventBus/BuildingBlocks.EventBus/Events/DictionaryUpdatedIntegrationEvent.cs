using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace BuildingBlocks.EventBus.Events
{
    public class DictionaryUpdatedIntegrationEvent<TEntity> : IntegrationEvent 
        where TEntity : class, new()
    {
        [JsonProperty("entities")]
        public IEnumerable<TEntity> Entities { get; set; }

        public DictionaryUpdatedIntegrationEvent(IEnumerable<TEntity> entities)
        {
            Entities = entities;
        }
    }
}
