using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BuildingBlocks.Security.Access
{
    public interface IAccessorFactory
    {
        IAccessor Create(ClaimsPrincipal user);
    }
}
