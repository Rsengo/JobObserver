using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Industries;
using Resumes.Dto.Models.Industries;

namespace Resumes.Dto.Profiles.Industries
{
    public class IndustryProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Industry, DtoIndustry>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoIndustry, Industry>();
        }
    }
}
