using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security;
using BuildingBlocks.Security.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security.Accessors
{
    public class AdminAccessor : AbstractAccessor
    {
        public AdminAccessor(
            IServiceProvider serviceProvider, 
            IImmutableDictionary<Type, Type> eventHandlersDictionary) : 
            base(serviceProvider, eventHandlersDictionary)
        {
        }

        public override Task<bool> HasPermissionAsync<TEntity>(AccessEvent<TEntity> @event, AccessOperation operation)
        {
            return Task.FromResult(true);
        }
    }
}
