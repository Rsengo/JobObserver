using BuildingBlocks.Security;
using BuildingBlocks.Security.Abstract;
using Resumes.API.Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Resumes.API.Security
{
    public class AccessEventFactoryMock : IAccessEventFactory
    {
        public AccessEvent<TEntity> Create<TEntity>(ClaimsPrincipal user, AccessOperation operation) 
            where TEntity : class
        {
            return new ApplicantAccessEvent<TEntity>(Guid.Empty, operation);
        }
    }
}
