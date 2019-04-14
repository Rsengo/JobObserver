using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Industries;
using Vacancies.Dto.Models.Industries;

namespace Vacancies.Dto.Profiles.Industries
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
        }
    }
}
