using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Security.Access
{
    public interface IAccessHandler<TEntity> where TEntity: class
    {
        Task<bool> HasPermissionAsync(TEntity entity, AccessOperation operation);

        Task<bool> HasPermissionAsync(IEnumerable<TEntity> entity, AccessOperation operation);

        Task<bool> HasPermissionAsync(IQueryable<TEntity> entity, AccessOperation operation);
    }
}
