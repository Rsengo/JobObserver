using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Security.Access
{
    public interface IAccessor
    {
        bool HasPermission<TEntity>(AccessOperation operation) 
            where TEntity : class;
    }
}
