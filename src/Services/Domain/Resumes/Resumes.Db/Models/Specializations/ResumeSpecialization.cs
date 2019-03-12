using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Resumes.Db.Models.Specializations
{
    public class ResumeSpecialization : RelationalEntity
    {
        public virtual Resume Resume { get; set; }

        public virtual long ResumeId { get; set; }

        public virtual Specialization Specialization { get; set; }

        public virtual long SpecializationId { get; set; }
    }
}
