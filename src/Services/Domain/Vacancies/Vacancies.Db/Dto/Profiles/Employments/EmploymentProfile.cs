using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Employments;
using Vacancies.Db.Dto.Models.Employments;

namespace Vacancies.Db.Dto.Profiles.Employments
{
    public class EmploymentProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Employment, DtoEmployment>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEmployment, Employment>();
        }
    }
}
