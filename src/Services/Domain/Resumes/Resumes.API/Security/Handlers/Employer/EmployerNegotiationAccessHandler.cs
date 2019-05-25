using BuildingBlocks.Security;
using BuildingBlocks.Security.Abstract;
using Microsoft.EntityFrameworkCore;
using Resumes.API.Security.Events;
using Resumes.Db.Models.Negotiations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security.Handlers.Employer
{
    public class EmployerNegotiationAccessHandler :
        IAccessHandler<EmployerAccessEvent<ResumeNegotiation>, ResumeNegotiation>
    {
        public async Task<bool> HasPermissionAsync(EmployerAccessEvent<ResumeNegotiation> @event, AccessOperation operation)
        {
            var allowedArray = new bool?[3];

            var companyId = @event.CompanyId;
            var entityAllowed = companyId == @event.Entity.CompanyId;
            allowedArray[0] = entityAllowed;

            var enumerableAllowed = @event.EnumerableEntities?.All(x => x.CompanyId == companyId);
            allowedArray[1] = enumerableAllowed;

            var queriableAllowed = await @event.QueriableEntities?.AllAsync(x => x.CompanyId == companyId);
            allowedArray[2] = queriableAllowed;

            var allowed = allowedArray.All(x => x != false);

            return allowed;
        }
    }
}
