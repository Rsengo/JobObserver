using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BuildingBlocks.Security.Abstract
{
    public interface IAccessEventFactory
    {
        AccessEvent<TEntity> Create<TEntity>(ClaimsPrincipal user, AccessOperation operation)
            where TEntity : class;
    }
}
