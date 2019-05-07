using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resumes.API.Security
{
    public class AdminAccessor : IAccessor
    {
        public bool HasPermission<TEntity>(TEntity entity, AccessOperation operation) 
            where TEntity : RelationalEntity
        {
            return true;
        }
    }
}
