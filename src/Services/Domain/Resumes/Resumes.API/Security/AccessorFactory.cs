using BuildingBlocks.Security.Abstract;
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
using Resumes.API.Security.Accessors;

namespace Resumes.API.Security
{
    public class AccessorFactory : IAccessorFactory
    { 
        private readonly ILogger<AccessorFactory> _logger;

        private readonly IServiceProvider _serviceProvider;

        public AccessorFactory(
            ILogger<AccessorFactory> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public AbstractAccessor Create(ClaimsPrincipal user)
        {
            if (user.IsInRole(Config.DefaultRoles.ADMIN))
            {
                var accessor = _serviceProvider.GetService(typeof(AdminAccessor)) as AbstractAccessor;

                if (accessor == null)
                {
                    throw new NullReferenceException("Не найден сервис авторизации для админа");
                }

                return accessor;
            }

            if (user.IsInRole(Config.DefaultRoles.APPLICANT))
            {
                var id = user.Claims
                    .First(x => x.Type == JwtClaimTypes.Subject)
                    .Value;
                var accessor = _serviceProvider.GetService(typeof(ApplicantAccessor)) as AbstractAccessor;

                if (accessor == null)
                {
                    throw new NullReferenceException("Не найден сервис авторизации для соискателя");
                }

                return accessor;
            }

            if (user.IsInRole(Config.DefaultRoles.EMPLOYER_MANAGER))
            {
                var organizationId = user.Claims
                    .First(x => x.Type == Config.JobObserverJwtClaimTypes.OrganizationId)
                    .Value;
                var accessor = _serviceProvider.GetService(typeof(EmployerManagerAccessor)) as AbstractAccessor;

                if (accessor == null)
                {
                    throw new NullReferenceException("Не найден сервис авторизации для менеджера компании");
                }

                return accessor;
            }

            if (user.IsInRole(Config.DefaultRoles.EDUCATIONAL_INSTITUTION_MANAGER))
            {
                var accessor = _serviceProvider.GetService(typeof(EducationalInstitutionManagerAccessor)) as AbstractAccessor;

                if (accessor == null)
                {
                    throw new NullReferenceException("Не найден сервис авторизации для менеджера учебного заведения");
                }

                return accessor;
            }

            var role = user.Claims.SingleOrDefault(x => x.Type == JwtClaimTypes.Role)?.Value ?? "роль не задана";

            throw new ArgumentException($"Не найден пользователь с указанной ролью: {role}");
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
