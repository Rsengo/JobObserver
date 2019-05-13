using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security.Access;
using Resumes.Db.Models;

namespace Resumes.API.Security
{
    public class EducationalInstitutionManagerAccessor : IAccessor
    {
        public bool HasPermission<TEntity>(TEntity entity, AccessOperation operation)
            where TEntity : RelationalEntity
        {
            return AccessOperation.READ == operation;
        }
    }
}