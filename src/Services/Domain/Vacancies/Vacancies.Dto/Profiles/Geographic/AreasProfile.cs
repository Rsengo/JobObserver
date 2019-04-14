﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Geographic;
using Vacancies.Dto.Models.Geographic;

namespace Vacancies.Dto.Profiles.Geographic
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
        }
    }
}
