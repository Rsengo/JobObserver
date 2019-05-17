using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingBlocks.Security
{
    public class AccessEvent<TEntity>
        where TEntity : class
    {
        public Guid Id { get; }

        public AccessOperation Operation { get; set; }

        public AccessEvent(AccessOperation operation)
        {
            Id = Guid.NewGuid();
            Operation = operation;
        }

        public AccessEvent(Guid id, AccessOperation operation)
        {
            Id = id;
            Operation = operation;
        }
    }
}
