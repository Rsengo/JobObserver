using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Industries;
using Dictionaries.Db.Dto.Models.Industries;

namespace Dictionaries.Db.Dto.Profiles.Industries
{
    public class IndustryProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Industry, DtoIndustry>()
                .ForMember(
                    dest => dest.Parent,
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoIndustry>(src.Parent)));

            CreateMap<Industry, DtoIndustrySync>()
                .ForMember(
                    dest => dest.Industries,
                    opt => opt.MapFrom(
                        src => src.Industries.Select(Mapper.Map<DtoIndustrySync>)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoIndustry, Industry>()
                .ForMember(
                    dest => dest.Parent,
                    opt => opt.MapFrom(
                        src => Mapper.Map<Industry>(src.Parent)))
                .ForMember(
                    dest => dest.Industries,
                    opt => opt.Ignore());

            CreateMap<DtoIndustrySync, Industry>()
                .ForMember(
                    dest => dest.Parent,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Industries,
                    opt => opt.MapFrom(
                        s => s.Industries.Select(Mapper.Map<Industry>)));
        }
    }
}
