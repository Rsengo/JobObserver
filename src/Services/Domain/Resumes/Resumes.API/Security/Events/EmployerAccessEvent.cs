using BuildingBlocks.Security;
using Resumes.Db.Models.Negotiations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security.Events
{
    public class EmployerAccessEvent<TEntity> :
        AccessEvent<TEntity>
        where TEntity : class
    {
        public long CompanyId { get; set; }

        public EmployerAccessEvent(
            long companyId,
            AccessOperation operation) :
            base(operation)
        {
            CompanyId = companyId;
        }

        public EmployerAccessEvent(
            Guid id,
            long companyId,
            AccessOperation operation) :
            base(id, operation)
        {
            CompanyId = companyId;
        }
    }
}
