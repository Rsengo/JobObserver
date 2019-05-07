using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.Security.Access;

namespace Resumes.API.Security
{
    using System.Collections.Immutable;
    using BuildingBlocks.EntityFramework.Models;
    using Resumes.Db.Models;

    public class ApplicantAccessor : IAccessor
    {
        private readonly string _applicantId;

        public ApplicantAccessor(string applicantId)
        {
            _applicantId = applicantId;
        }

        public bool HasPermission<TEntity>(TEntity entity, AccessOperation operation) 
            where TEntity : RelationalEntity
        {
            if (entity is Resume casted)
            {
                return casted.ApplicantId.ToString("D") == _applicantId
                    ? true
                    : false;
            }

            return true;
        }
    }
}
