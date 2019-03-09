using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;
using Resumes.Db.Models.Specializations;

namespace Resumes.Db.Models.Educations
{
    public class EducationSpecialization : RelationalEntity
    {
        public virtual Education Education { get; set; }

        public virtual long EducationId { get; set; }

        public virtual Specialization Specialization { get; set; }

        public virtual long SpecializationId { get; set; }
    }
}
