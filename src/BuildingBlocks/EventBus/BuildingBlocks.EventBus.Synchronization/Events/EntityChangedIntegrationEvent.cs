using System.Collections.Generic;
using BuildingBlocks.EventBus.Events;
using Newtonsoft.Json;

namespace BuildingBlocks.EventBus.Synchronization.Events
{
    public class EntityChangedIntegrationEvent<TEntity> : EntityChangedIntegrationEvent<TEntity, long>
        where TEntity : class, new()
    {
    }

    public class EntityChangedIntegrationEvent<TEntity, TKey> : IntegrationEvent
        where TEntity : class, new()
    {
        [JsonProperty]
        public IEnumerable<TEntity> Created { get; set; }

        [JsonProperty]
        public IEnumerable<TEntity> Updated { get; set; }

        [JsonProperty]
        public IEnumerable<TKey> Deleted { get; set; }

        public EntityChangedIntegrationEvent(
            IEnumerable<TEntity> created,
            IEnumerable<TEntity> updated,
            IEnumerable<TKey> deleted)
        {
            Created = created;
            Updated = updated;
            Deleted = deleted;
        }

        public EntityChangedIntegrationEvent()
        {
            Created = new List<TEntity>();
            Updated = new List<TEntity>();
            Deleted = new List<TKey>();
        }
    }
}