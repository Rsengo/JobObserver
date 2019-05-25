using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Security.Abstract
{
    public interface IAccessHandler<TEvent, TEntity> 
        where TEvent : AccessEvent<TEntity>
        where TEntity : class
    {
        Task<bool> HasPermissionAsync(TEvent @event, AccessOperation operation);
    }
}
