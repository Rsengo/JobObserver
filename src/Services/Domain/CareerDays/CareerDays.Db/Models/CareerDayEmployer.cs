using System;
using System.Collections.Generic;
using System.Text;

namespace CareerDays.Db.Models
{
    using BuildingBlocks.EntityFramework.Models;

    public class CareerDayEmployer : RelationalEntity
    {
        public virtual Employer Employer { get; set; }

        public virtual long EmployerId { get; set; }

        public virtual CareerDay CareerDay { get; set; }

        public virtual long CareerDayId { get; set; }
    }
}
