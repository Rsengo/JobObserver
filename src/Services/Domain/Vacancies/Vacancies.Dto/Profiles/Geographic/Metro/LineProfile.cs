using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Geographic.Metro;
using Vacancies.Dto.Models.Geographic.Metro;

namespace Vacancies.Dto.Profiles.Geographic.Metro
{
    public class LineProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Line, DtoLine>()
                .ForMember(
                    dest => dest.Metro,
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoMetro>(src.Metro)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoLine, Line>()
                .ForMember(
                    dest => dest.Metro,
                    opt => opt.Ignore())
                .ForMember(
                    dest => dest.Stations,
                    opt => opt.Ignore());
        }
    }
}
