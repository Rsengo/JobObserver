using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;

namespace Resumes.Db.Models.Schedules
{
    public class ResumeSchedule : RelationalEntity
    {
        public virtual Resume Resume { get; set; }

        public virtual long ResumeId { get; set; }

        public virtual Schedule Schedule { get; set; }

        public virtual long ScheduleId { get; set; }
    }
}
