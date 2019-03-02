using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using CareerDays.Db.Models.Geographic;
using CareerDays.Dto.Models.Geographic;

namespace CareerDays.Dto.Profiles.Geographic
{
    public class AreasProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Area, DtoArea>()
                .ForMember(x => x.Parent, 
                    opt => opt.MapFrom(
                        src => src.Parent));
        }

        public override void Dto2Entity()
        {
            throw new NotImplementedException();
        }
    }
}
