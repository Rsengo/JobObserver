using BuildingBlocks.Security.Access;
using Resumes.Db.Models.Negotiations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security.Handlers.Employer
{
    public class EmployerNegotiationAccessHandler : IAccessHandler<ResumeNegotiation>
    {
        public Task<bool> HasPermissionAsync(ResumeNegotiation entity, AccessOperation operation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPermissionAsync(IEnumerable<ResumeNegotiation> entity, AccessOperation operation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPermissionAsync(IQueryable<ResumeNegotiation> entity, AccessOperation operation)
        {
            throw new NotImplementedException();
        }
    }
}
