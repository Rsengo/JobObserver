using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moodle.API.Factories
{
    public class UsernameFactory : IUsernameFactory
    {
        public string CreateApplicantUsername(Guid id)
        {
            return $"applicant_{id.ToString("D")}";
        }

        public string CreateEmployerUsername(long id)
        {
            return $"employer_{id}";
        }
    }
}
