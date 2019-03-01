using System.Collections.Generic;
using BuildingBlocks.EventBus.Events;
using Newtonsoft.Json;

namespace BuildingBlocks.EventBus.Synchronization.Events
{
    public class EntityChangedIntegrationEvent<TEntity> : IntegrationEvent
        where TEntity : class, new()
    {
        [JsonProperty("created")]
        public IEnumerable<TEntity> Created { get; set; }

        [JsonProperty("updated")]
        public IEnumerable<TEntity> Updated { get; set; }

        [JsonProperty("deleted")]
        public IEnumerable<long> Deleted { get; set; }

        public EntityChangedIntegrationEvent(
            IEnumerable<TEntity> created,
            IEnumerable<TEntity> updated,
            IEnumerable<long> deleted)
        {
            Created = created;
            Updated = updated;
            Deleted = deleted;
        }

        public EntityChangedIntegrationEvent() { }
    }
}