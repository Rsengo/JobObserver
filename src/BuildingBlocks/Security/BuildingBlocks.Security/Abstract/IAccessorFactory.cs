using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BuildingBlocks.Security.Abstract
{
    public interface IAccessorFactory
    {
        AbstractAccessor Create(ClaimsPrincipal user);

        bool TryCreate(ClaimsPrincipal user, out AbstractAccessor accessor);
    }
}
