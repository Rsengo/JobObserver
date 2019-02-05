using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.Database.EntityFramework.Models;

namespace Employers.Db.Models
{
    public class Partners: RelationalEntity
    {
        public virtual Employer Employer { get; set; }

        public virtual long EmployerId { get; set; }

        public virtual long EducationalInstitutionId { get; set; }
    }
}
