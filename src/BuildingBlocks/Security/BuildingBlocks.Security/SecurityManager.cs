using BuildingBlocks.Security;
using BuildingBlocks.Security.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingBlocks.Security
{
    public class SecurityManager : ISecurityManager
    {
        public IHttpContextAccessor HttpContextAccessor { get; }

        public IAccessorFactory AccessorFactory { get; }

        public IAccessEventFactory EventFactory { get; }

        public SecurityManager(
            IHttpContextAccessor contextAccessor,
            IAccessorFactory accessorFactory,
            IAccessEventFactory eventFactory)
        {
            HttpContextAccessor = contextAccessor;
            AccessorFactory = accessorFactory;
            EventFactory = eventFactory;
        }

        public AbstractAccessor CreateAccessor()
        {
            return AccessorFactory.Create(HttpContextAccessor.HttpContext.User);
        }

        public AccessEvent<TEntity> CreateEvent<TEntity>(AccessOperation operation) 
            where TEntity : class
        {
            return EventFactory.Create<TEntity>(HttpContextAccessor.HttpContext.User, operation);
        }

        public AccessEvent<TEntity> CreateEvent<TEntity>(TEntity entity, AccessOperation operation) 
            where TEntity : class
        {
            var @event = CreateEvent<TEntity>(operation);
            @event.Entity = entity;
            return @event;
        }

        public AccessEvent<TEntity> CreateEvent<TEntity>(IEnumerable<TEntity> entities, AccessOperation operation) 
            where TEntity : class
        {
            var @event = CreateEvent<TEntity>(operation);
            @event.EnumerableEntities = entities;
            return @event;
        }

        public AccessEvent<TEntity> CreateEvent<TEntity>(IQueryable<TEntity> entities, AccessOperation operation) 
            where TEntity : class
        {
            var @event = CreateEvent<TEntity>(operation);
            @event.QueriableEntities = entities;
            return @event;
        }

        public async Task<bool> HasPermissionAsync<TEntity>(TEntity entity, AccessOperation operation) 
            where TEntity : class
        {
            var @event = CreateEvent(entity, operation);
            var accessor = CreateAccessor();
            var allowed = await accessor.HasPermissionAsync(@event, operation);

            return allowed;
        }

        public async Task<bool> HasPermissionAsync<TEntity>(IEnumerable<TEntity> entities, AccessOperation operation) 
            where TEntity : class
        {
            var @event = CreateEvent(entities, operation);
            var accessor = CreateAccessor();
            var allowed = await accessor.HasPermissionAsync(@event, operation);

            return allowed;
        }

        public async Task<bool> HasPermissionAsync<TEntity>(IQueryable<TEntity> entities, AccessOperation operation) 
            where TEntity : class
        {
            var @event = CreateEvent(entities, operation);
            var accessor = CreateAccessor();
            var allowed = await accessor.HasPermissionAsync(@event, operation);

            return allowed;
        }
    }
}
