using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;
using Employers.Db.Models.EducationalInstitutions;

namespace Employers.Db.Models
{
    public class Partners: RelationalEntity
    {
        public virtual Employer Employer { get; set; }

        public virtual long EmployerId { get; set; }

        public virtual long EducationalInstitutionId { get; set; }

        public virtual EducationalInstitution EducationalInstitution { get; set; }
    }
}
