using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security;
using BuildingBlocks.Security.Abstract;
using Resumes.Db.Models;

namespace Resumes.API.Security.Accessors
{
    public class EducationalInstitutionManagerAccessor : AbstractAccessor
    {
        public EducationalInstitutionManagerAccessor(
            IServiceProvider serviceProvider, 
            IImmutableDictionary<Type, Type> eventHandlersDictionary) : 
            base(serviceProvider, eventHandlersDictionary)
        {
        }

        public override Task<bool> HasPermissionAsync<TEntity>(AccessEvent<TEntity> @event, AccessOperation operation) 
        {
            return Task.FromResult(operation == AccessOperation.READ);
        }
    }
}