using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.EntityFramework.Models;
using BuildingBlocks.DataTransfer.Models;

namespace CareerDays.Dto.Models
{
    public class DtoCareerDayEducationalInstitution : DtoEntity
    {
        public virtual long EducationalInstitutionId { get; set; }

        public virtual long CareerDayId { get; set; }
    }
}
