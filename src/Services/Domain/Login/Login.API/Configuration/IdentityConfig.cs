using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.API.Configuration
{
    public static class IdentityConfig
    {
        public static IDictionary<DefaultRole, string> GetRolesInfo()
        {
            var dict = new Dictionary<DefaultRole, string>
            {
                {DefaultRole.APPLICANT, "Applicant"},
                {DefaultRole.EMPLOYER_MANAGER, "Employer Manager"},
                {DefaultRole.EDUCATIONAL_INSTITUTION_MANAGER, "Educational Institution Manager"},
                {DefaultRole.ADMIN, "Admin"},
            };

            return dict;
        }

        public static IEnumerable<string> GetRoleNames()
        {
            var dict = GetRolesInfo();
            var roleNames = dict.Select(x => x.Value);

            return roleNames;
        }
    }

    public enum DefaultRole
    {
        APPLICANT,
        EMPLOYER_MANAGER,
        EDUCATIONAL_INSTITUTION_MANAGER,
        ADMIN
    }
}
