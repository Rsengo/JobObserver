using System;
using BuildingBlocks.Database.Entity;

namespace BuildingBlocks.MongoDB.Models
{
    public class MongoDictionary: MongoEntity, IDictionaryEntity
    {
        /// <inheritdoc />
        public virtual string Name { get; set; }

        /// <inheritdoc />
        public virtual Guid GlobalId { get; set; }
    }
}
