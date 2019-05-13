using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security.Access;
using Resumes.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resumes.Db.Models.Certificates;
using Resumes.Db.Models.Geographic;
using Resumes.Db.Models.Negotiations;
using Resumes.Db.Models.ResumeAreas;

namespace Resumes.API.Security
{
    public class EmployerManagerAccessor : IAccessor
    {
        private readonly long _companyId;

        public EmployerManagerAccessor(long companyId)
        {
            _companyId = companyId;
        }

        public bool HasPermission<TEntity>(TEntity entity, AccessOperation operation)
            where TEntity : RelationalEntity
        {
            if (entity is ResumeNegotiation casted)
            {
                var companyId = casted.CompanyId;
                return companyId == _companyId;
            }

            return AccessOperation.READ == operation;
        }
    }
}
