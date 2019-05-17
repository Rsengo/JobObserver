using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Security.Abstract
{
    public interface ISecurityManager
    {
        HttpContext HttpContext { get; set; }

        IAccessorFactory AccessorFactory { get; }

        IAccessEventFactory EventFactory { get; }

        AccessEvent<TEntity> CreateEvent<TEntity>(AccessOperation operation) 
            where TEntity : class;

        AccessEvent<TEntity> CreateEvent<TEntity>(TEntity entity, AccessOperation operation)
            where TEntity : class;

        AccessEvent<TEntity> CreateEvent<TEntity>(IEnumerable<TEntity> entities, AccessOperation operation)
            where TEntity : class;

        AccessEvent<TEntity> CreateEvent<TEntity>(IQueryable<TEntity> entities, AccessOperation operation)
            where TEntity : class;

        AbstractAccessor CreateAccessor();

        Task<bool> HasPermissionAsync<TEntity>(TEntity entity, AccessOperation operation)
            where TEntity : class;

        Task<bool> HasPermissionAsync<TEntity>(IEnumerable<TEntity> entities, AccessOperation operation)
            where TEntity : class;

        Task<bool> HasPermissionAsync<TEntity>(IQueryable<TEntity> entities, AccessOperation operation)
            where TEntity : class;
    }
}
