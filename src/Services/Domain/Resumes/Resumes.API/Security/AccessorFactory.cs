using BuildingBlocks.Security.Access;
using IdentityModel;
using Microsoft.Extensions.Logging;
using Resumes.API.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Resumes.Db;
using BuildingBlocks.EntityFramework.Models;

namespace Resumes.API.Security
{
    public class AccessorFactory : IAccessorFactory<RelationalEntity>
    {
        private ILogger<AccessorFactory> _logger;

        private ResumesDbContext _context;

        public AccessorFactory(
            ResumesDbContext context,
            ILogger<AccessorFactory> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IAccessor<RelationalDictionary> Create(ClaimsPrincipal user)
        {
            if (user.IsInRole(Config.DefaultRoles.ADMIN))
                return new AdminAccessor();

            if (user.IsInRole(Config.DefaultRoles.APPLICANT))
            {
                var id = user.Claims
                    .First(x => x.Type == JwtClaimTypes.Subject)
                    .Value;
                return new ApplicantAccessor(Guid.Parse(id), _context);
            }

            if (user.IsInRole(Config.DefaultRoles.EMPLOYER_MANAGER))
            {
                var organizationId = user.Claims
                    .First(x => x.Type == Config.JobObserverJwtClaimTypes.OrganizationId)
                    .Value;
                return new EmployerManagerAccessor(long.Parse(organizationId));
            }

            if (user.IsInRole(Config.DefaultRoles.EDUCATIONAL_INSTITUTION_MANAGER))
            {
                return new EducationalInstitutionManagerAccessor();
            }

            var role = user.Claims.SingleOrDefault(x => x.Type == JwtClaimTypes.Role)?.Value ?? "роль не задана";

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
