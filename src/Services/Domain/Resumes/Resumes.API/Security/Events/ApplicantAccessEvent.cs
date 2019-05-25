using BuildingBlocks.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security.Events
{
    public class ApplicantAccessEvent<TEntity> :
        AccessEvent<TEntity>
        where TEntity : class
    {
        public Guid ApplicantId { get; set; }

        public ApplicantAccessEvent(
            Guid applicantId,
            AccessOperation operation) :
            base(operation)
        {
            ApplicantId = applicantId;
        }

        public ApplicantAccessEvent(
            Guid id,
            Guid applicantId,
            AccessOperation operation) :
            base(id, operation)
        {
            ApplicantId = applicantId;
        }
    }
}
