using BuildingBlocks.Security.Access;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Resumes.API.Security
{
    public class AccessorFactoryMock : IAccessorFactory
    {
        private ILogger<AccessorFactoryMock> _logger;

        public AccessorFactoryMock(ILogger<AccessorFactoryMock> logger)
        {
            _logger = logger;
        }

        public IAccessor Create(ClaimsPrincipal user)
        {
            _logger.LogWarning("Использован мок прав доступа");
            return new AdminAccessor();
        }
    }
}
