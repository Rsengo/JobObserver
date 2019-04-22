using System;
using System.Collections.Immutable;
using BuildingBlocks.Security.Access;

namespace Resumes.API.Security
{
    public abstract class BaseAccessor : IAccessor
    {
        public IImmutableDictionary<Type, AccessOperation> AccessLevels { get; }

        protected BaseAccessor()
        {
            AccessLevels = GetAccessLevels();
        }

        public bool HasPermission<TEntity>(AccessOperation operation)
            where TEntity : class
        {
            var type = typeof(TEntity);

            var exists = AccessLevels.TryGetValue(type, out var enableOperation);
            if (!exists)
                return false;

            var enable = enableOperation == operation;
            return enable;
        }

        protected abstract IImmutableDictionary<Type, AccessOperation> GetAccessLevels();
    }
}
