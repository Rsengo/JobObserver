using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Employments;
using Resumes.Db.Dto.Models.Employments;

namespace Resumes.Db.Dto.Profiles.Employments
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
