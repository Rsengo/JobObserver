using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moodle.API.Factories
{
    public interface IUsernameFactory
    {
        string CreateEmployerUsername(long id);

        string CreateApplicantUsername(Guid id);
    }
}
