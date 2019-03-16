using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Industries;
using Vacancies.Dto.Models.Industries;

namespace Vacancies.Dto.Profiles.Industries
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
