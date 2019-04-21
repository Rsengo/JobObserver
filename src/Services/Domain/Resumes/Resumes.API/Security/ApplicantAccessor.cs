using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildingBlocks.Security.Access;

namespace Resumes.API.Security
{
    using System.Collections.Immutable;

    using Resumes.Db.Models;

    public class ApplicantAccessor : BaseAccessor
    {
        protected override IImmutableDictionary<Type, AccessOperation> GetAccessLevels()
        {
            //var dict = new Dictionary<Type, AccessOperation>
            //{
            //    {typeof(Resume),  }
            //}.ToImmutableDictionary();
            return null;
        }
    }
}
