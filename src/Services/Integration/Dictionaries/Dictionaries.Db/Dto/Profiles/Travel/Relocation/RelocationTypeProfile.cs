using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Travel.Relocation;
using Dictionaries.Db.Dto.Models.Travel.Relocation;

namespace Dictionaries.Db.Dto.Profiles.Travel.Relocation
{
    public class RelocationTypeProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<RelocationType, DtoRelocationType>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoRelocationType, RelocationType>();
        }
    }
}
