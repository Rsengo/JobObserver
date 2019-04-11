using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace CareerDays.Db.Models
{
    public class CareerDayEducationalInstitution : RelationalEntity
    {
        public virtual EducationalInstitution EducationalInstitution { get; set; }

        public virtual long EducationalInstitutionId { get; set; }

        public virtual CareerDay CareerDay { get; set; }

        public virtual long CareerDayId { get; set; }
    }
}
