using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.DataTransfer.Models;

namespace CareerDays.Db.Dto.Models
{
    public class DtoCareerDayEmployer : DtoEntity
    {
        public virtual long EmployerId { get; set; }

        public virtual long CareerDayId { get; set; }
    }
}
