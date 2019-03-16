﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Geographic.Metro;
using Vacancies.Dto.Models.Geographic.Metro;

namespace Vacancies.Dto.Profiles.Geographic.Metro
{
    public class StationProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Station, DtoStation>()
                .ForMember(
                    dest => dest.Line, 
                    opt => opt.MapFrom(
                        src => Mapper.Map<DtoLine>(src.Line)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoStation, Station>()
                .ForMember(
                    dest => dest.Line, 
                    opt => opt.Ignore());
        }
    }
}
