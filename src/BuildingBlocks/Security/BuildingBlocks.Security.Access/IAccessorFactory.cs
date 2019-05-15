using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BuildingBlocks.Security.Access
{
    public interface IAccessorFactory<TBaseEntity> 
        where TBaseEntity: class
    {
        IAccessor<TBaseEntity> Create(ClaimsPrincipal user);
    }
}
