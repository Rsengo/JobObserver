﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Specializations;
using Vacancies.Db.Dto.Models.Specializations;

namespace Vacancies.Db.Dto.Profiles.Specializations
{
    public class SpecializationProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Specialization, DtoSpecialization>()
                .ForMember(
                    d => d.Parent,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSpecialization>(s.Parent)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoSpecialization, Specialization>()
                .ForMember(
                    d => d.Parent,
                    o => o.MapFrom(
                        s => Mapper.Map<Specialization>(s.Parent)));
        }
    }
}
