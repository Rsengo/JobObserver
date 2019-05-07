using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security.Access;
using Resumes.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security
{
    public class ManagerAccessor : IAccessor
    {
        public bool HasPermission<TEntity>(TEntity entity, AccessOperation operation)
            where TEntity : RelationalEntity
        {
            if (entity is Resume casted)
                return AccessOperation.READ == operation;

            return true;
        }
    }
}
