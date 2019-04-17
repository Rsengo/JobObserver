using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Industries;
using Resumes.Db.Dto.Models.Industries;

namespace Resumes.Db.Dto.Profiles.Industries
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
