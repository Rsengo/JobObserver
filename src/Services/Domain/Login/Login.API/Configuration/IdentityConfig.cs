using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API.Configuration
{
    public static class IdentityConfig
    {
        public static IEnumerable<string> GetRoleNames()
        {
            yield return DefaultRoles.APPLICANT;
            yield return DefaultRoles.EMPLOYER_MANAGER;
            yield return DefaultRoles.EDUCATIONAL_INSTITUTION_MANAGER;
            yield return DefaultRoles.ADMIN;
        }

        public static class DefaultRoles
        {
            public const string APPLICANT = "Applicant";
            public const string EMPLOYER_MANAGER = "Employer Manager";
            public const string EDUCATIONAL_INSTITUTION_MANAGER = "Educational Institution Manager";
            public const string ADMIN = "Admin";
        }

        public static class JobObserverJwtClaimTypes
        {
            public const string OrganizationId = "organization_id";
        }
    }
}
