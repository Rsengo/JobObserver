using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resumes.Db;
using Resumes.Db.Models.Certificates;
using Resumes.Db.Models.Driving;
using Resumes.Db.Models.Educations;
using Resumes.Db.Models.Employments;
using Resumes.Db.Models.Experiences;
using System.Collections.Immutable;
using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.Security;
using BuildingBlocks.Security.Abstract;
using Resumes.Db.Models;
using Resumes.Db.Models.Languages;
using Resumes.Db.Models.Negotiations;
using Resumes.Db.Models.ResumeAreas;
using Resumes.Db.Models.Salaries;
using Resumes.Db.Models.Schedules;
using Resumes.Db.Models.Skills;
using Resumes.Db.Models.Specializations;
using Resumes.Db.Models.Travel.Relocation;

namespace Resumes.API.Security.Accessors
{
    public class ApplicantAccessor : AbstractAccessor
    {
        public ApplicantAccessor(
            IServiceProvider serviceProvider, 
            IImmutableDictionary<Type, Type> eventHandlersDictionary) : 
            base(serviceProvider, eventHandlersDictionary)
        {
        }
    }
}
