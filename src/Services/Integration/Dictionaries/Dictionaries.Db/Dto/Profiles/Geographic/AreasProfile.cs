using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Geographic;
using Dictionaries.Db.Dto.Models.Geographic;

namespace Dictionaries.Db.Dto.Profiles.Geographic
{
    public class AreasProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Area, DtoArea>()
                .ForMember(
                    dest => dest.Parent, 
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoArea>(src.Parent)));

            CreateMap<Area, DtoAreaSync>()
                .ForMember(
                    dest => dest.Areas,
                    opt => opt.MapFrom(
                        src => src.Areas.Select(Mapper.Map<DtoAreaSync>)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoArea, Area>()
                .ForMember(
                    dest => dest.Parent, 
                    opt => opt.MapFrom(
                        src => Mapper.Map<Area>(src.Parent)))
                .ForMember(
                    dest => dest.Metro, 
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Areas, 
                    opt => opt.Ignore());

            CreateMap<DtoAreaSync, Area>()
                .ForMember(
                    dest => dest.Parent,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Metro,
                    opt => opt.Ignore())                
                .ForMember(
                    dest => dest.MetroId,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Areas,
                    opt => opt.MapFrom(
                        s => s.Areas.Select(Mapper.Map<Area>)));
        }
    }
}
