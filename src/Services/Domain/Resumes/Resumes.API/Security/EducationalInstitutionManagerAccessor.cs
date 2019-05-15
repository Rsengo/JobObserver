using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security.Access;
using Resumes.Db.Models;

namespace Resumes.API.Security
{
    public class EducationalInstitutionManagerAccessor : IAccessor<RelationalEntity>
    {
        public Task<bool> HasPermissionAsync<TEntity>(TEntity entity, AccessOperation operation) 
            where TEntity : RelationalEntity
        {
            return Task.FromResult(AccessOperation.READ == operation);
        }

        public Task<bool> HasPermissionAsync<TEntity>(IEnumerable<TEntity> entity, AccessOperation operation) 
            where TEntity : RelationalEntity
        {
            return Task.FromResult(AccessOperation.READ == operation);
        }

        public Task<bool> HasPermissionAsync<TEntity>(IQueryable<TEntity> entity, AccessOperation operation) 
            where TEntity : RelationalEntity
        {
            return Task.FromResult(AccessOperation.READ == operation);
        }
    }
}