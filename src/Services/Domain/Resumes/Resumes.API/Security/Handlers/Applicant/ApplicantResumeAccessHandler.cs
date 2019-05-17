using BuildingBlocks.Security;
using BuildingBlocks.Security.Abstract;
using Microsoft.EntityFrameworkCore;
using Resumes.API.Security.Events;
using Resumes.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security.Handlers.Applicant
{
    public class ApplicantResumeAccessHandler : IAccessHandler<ApplicantAccessEvent<Resume>, Resume>
    {
        public async Task<bool> HasPermissionAsync(ApplicantAccessEvent<Resume> @event, AccessOperation operation)
        {
            var allowedArray = new bool?[3];

            var applicantId = @event.ApplicantId;
            var entityAllowed = applicantId == @event.Entity.ApplicantId;
            allowedArray[0] = entityAllowed;

            var enumerableAllowed = @event.EnumerableEntities?.All(x => x.ApplicantId == applicantId);
            allowedArray[1] = enumerableAllowed;

            var queriableAllowed = await @event.QueriableEntities?.AllAsync(x => x.ApplicantId == applicantId);
            allowedArray[2] = queriableAllowed;

            var allowed = allowedArray.All(x => x != false);

            return allowed;
        }
    }
}
