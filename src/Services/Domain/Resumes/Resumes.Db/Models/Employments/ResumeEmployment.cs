using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Resumes.Db.Models.Employments
{
    public class ResumeEmployment : RelationalEntity
    {
        public virtual Resume Resume { get; set; }

        public virtual long ResumeId { get; set; }

        public virtual Employment Employment { get; set; }

        public virtual long EmploymentId { get; set; }
    }
}
