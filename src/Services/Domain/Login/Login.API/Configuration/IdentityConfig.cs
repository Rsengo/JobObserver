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
            public static string APPLICANT = "Applicant";
            public static string EMPLOYER_MANAGER = "Employer Manager";
            public static string EDUCATIONAL_INSTITUTION_MANAGER = "Educational Institution Manager";
            public static string ADMIN = "Admin";
        }
    }
}
