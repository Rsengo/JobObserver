using BuildingBlocks.Security.Access;
using Resumes.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security.Handlers.Applicant
{
    public class ApplicantResumeAccessHandler : IAccessHandler<Resume>
    {
        public bool HasPermission(Resume entity, AccessOperation operation)
        {
            throw new NotImplementedException();
        }

        public bool HasPermission(IEnumerable<Resume> entity, AccessOperation operation)
        {
            throw new NotImplementedException();
        }
    }
}
