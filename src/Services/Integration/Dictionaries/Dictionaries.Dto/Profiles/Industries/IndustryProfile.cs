using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Industries;
using Dictionaries.Dto.Models.Industries;

namespace Dictionaries.Dto.Profiles.Industries
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
