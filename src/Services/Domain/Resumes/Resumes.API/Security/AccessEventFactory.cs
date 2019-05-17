using BuildingBlocks.Security;
using BuildingBlocks.Security.Abstract;
using IdentityModel;
using Resumes.API.Configuration;
using Resumes.API.Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Resumes.API.Security
{
    public class AccessEventFactory : IAccessEventFactory
    {
        public AccessEvent<TEntity> Create<TEntity>(ClaimsPrincipal user, AccessOperation operation) 
            where TEntity : class
        {
            if (user.IsInRole(Config.DefaultRoles.ADMIN))
                return new AccessEvent<TEntity>(operation);

            if (user.IsInRole(Config.DefaultRoles.APPLICANT))
            {
                var id = user.Claims
                    .First(x => x.Type == JwtClaimTypes.Subject)
                    .Value;
                return new ApplicantAccessEvent<TEntity>(Guid.Parse(id), operation);
            }

            if (user.IsInRole(Config.DefaultRoles.EMPLOYER_MANAGER))
            {
                var organizationId = user.Claims
                    .First(x => x.Type == Config.JobObserverJwtClaimTypes.OrganizationId)
                    .Value;
                return new EmployerAccessEvent<TEntity>(long.Parse(organizationId), operation);
            }

            if (user.IsInRole(Config.DefaultRoles.EDUCATIONAL_INSTITUTION_MANAGER))
            {
                return new AccessEvent<TEntity>(operation);
            }

            var role = user.Claims.SingleOrDefault(x => x.Type == JwtClaimTypes.Role)?.Value ?? "роль не задана";

            throw new ArgumentException($"Не найден пользователь с указанной ролью: {role}");
        }
    }
}
