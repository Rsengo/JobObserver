using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Employments;
using Dictionaries.Dto.Models.Employments;

namespace Dictionaries.Dto.Profiles.Employments
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
