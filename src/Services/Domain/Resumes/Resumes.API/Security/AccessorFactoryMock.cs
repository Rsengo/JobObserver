using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security.Abstract;
using Microsoft.Extensions.Logging;
using Resumes.API.Security.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Resumes.API.Security
{
    public class AccessorFactoryMock : IAccessorFactory
    {
        private readonly ILogger<AccessorFactoryMock> _logger;

        private readonly IServiceProvider _serviceProvider;

        public AccessorFactoryMock(
            ILogger<AccessorFactoryMock> logger, 
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public AbstractAccessor Create(ClaimsPrincipal user)
        {
            _logger.LogWarning("Использован мок прав доступа");

            if (!(_serviceProvider.GetService(typeof(AdminAccessor)) is AbstractAccessor accessor))
            {
                throw new NullReferenceException("Не найден сервис авторизации для админа");
            }

            return accessor;
        }

        public bool TryCreate(ClaimsPrincipal user, out AbstractAccessor accessor)
        {
            try
            {
                accessor = Create(user);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);

                accessor = null;
                return false;
            }
        }
    }
}
