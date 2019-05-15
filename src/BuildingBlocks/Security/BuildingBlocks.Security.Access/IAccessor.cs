using BuildingBlocks.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Security.Access
{
    public interface IAccessor<TBaseEntity> 
        where TBaseEntity: class
    {
        Task<bool> HasPermissionAsync<TEntity>(TEntity entity, AccessOperation operation)
            where TEntity : TBaseEntity;

        Task<bool> HasPermissionAsync<TEntity>(IEnumerable<TEntity> entity, AccessOperation operation)
            where TEntity : TBaseEntity;

        Task<bool> HasPermissionAsync<TEntity>(IQueryable<TEntity> entity, AccessOperation operation)
            where TEntity : TBaseEntity;
    }
}
