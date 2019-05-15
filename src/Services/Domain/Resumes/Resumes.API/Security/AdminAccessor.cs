using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security
{
    public class AdminAccessor : IAccessor<RelationalEntity>
    {
        public Task<bool> HasPermissionAsync<TEntity>(TEntity entity, AccessOperation operation) 
            where TEntity : RelationalEntity
        {
            return Task.FromResult(true);
        }

        public Task<bool> HasPermissionAsync<TEntity>(IEnumerable<TEntity> entity, AccessOperation operation) 
            where TEntity : RelationalEntity
        {
            return Task.FromResult(true);
        }

        public Task<bool> HasPermissionAsync<TEntity>(IQueryable<TEntity> entity, AccessOperation operation) 
            where TEntity : RelationalEntity
        {
            return Task.FromResult(true);
        }
    }
}
