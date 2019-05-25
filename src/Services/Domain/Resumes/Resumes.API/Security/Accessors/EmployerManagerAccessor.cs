using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security.Abstract;
using Resumes.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resumes.Db.Models.Certificates;
using Resumes.Db.Models.Geographic;
using Resumes.Db.Models.Negotiations;
using Resumes.Db.Models.ResumeAreas;
using System.Collections.Immutable;
using Resumes.API.Security.Handlers.Employer;
using BuildingBlocks.Security;

namespace Resumes.API.Security.Accessors
{
    public class EmployerManagerAccessor : AbstractAccessor
    {
        public EmployerManagerAccessor(
            IServiceProvider serviceProvider, 
            IImmutableDictionary<Type, Type> eventHandlersDictionary) : 
            base(serviceProvider, eventHandlersDictionary)
        {
        }

        protected override Task<bool> OnHandlerNotFound<TEntity>(
            AccessEvent<TEntity> @event, 
            AccessOperation operation)
        {
            return Task.FromResult(operation == AccessOperation.READ);
        }
    }
}
