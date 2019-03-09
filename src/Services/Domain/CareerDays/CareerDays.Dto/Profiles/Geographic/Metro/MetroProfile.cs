using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using CareerDays.Dto.Models.Geographic;
using CareerDays.Dto.Models.Geographic.Metro;

namespace CareerDays.Dto.Profiles.Geographic.Metro
{
    public class MetroProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Db.Models.Geographic.Metro.Metro, DtoMetro>()
                .ForMember(
                    dest => dest.Area, 
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoArea>(src.Area)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoMetro, Db.Models.Geographic.Metro.Metro>()
                .ForMember(
                    dest => dest.Lines, 
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Area, 
                    opt => opt.Ignore());
        }
    }
}
