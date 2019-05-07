using BuildingBlocks.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Security.Access
{
    public interface IAccessor
    {
        bool HasPermission<TEntity>(TEntity entity, AccessOperation operation)
            where TEntity : RelationalEntity;
    }
}
