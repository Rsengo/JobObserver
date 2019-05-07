using BuildingBlocks.Security.Access;
using IdentityModel;
using Microsoft.Extensions.Logging;
using Resumes.API.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Resumes.API.Security
{
    public class AccessorFactory : IAccessorFactory
    {
        private ILogger<AccessorFactory> _logger;

        public AccessorFactory(ILogger<AccessorFactory> logger)
        {
            _logger = logger;
        }

        public IAccessor Create(ClaimsPrincipal user)
        {
            if (user.IsInRole(Roles.ADMIN))
                return new AdminAccessor();

            if (user.IsInRole(Roles.APPLICANT))
            {
                var id = user.Claims
                    .First(x => x.Type == JwtClaimTypes.Subject)
                    .Value;
                return new ApplicantAccessor(id);
            }

            if (user.IsInRole(Roles.EDUCATIONAL_INSTITUTION_MANAGER) ||
                user.IsInRole(Roles.EMPLOYER_MANAGER))
            {
                return new ManagerAccessor();
            }

            var role = user.Claims.SingleOrDefault(x => x.Type == JwtClaimTypes.Role).Value;

            throw new ArgumentException($"Не найден пользователь с указанной ролью: {role}");
        }

        public bool TryCreate(ClaimsPrincipal user, out IAccessor accessor)
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
