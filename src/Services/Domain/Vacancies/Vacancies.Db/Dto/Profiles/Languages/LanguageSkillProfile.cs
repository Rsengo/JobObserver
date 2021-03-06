﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Languages;
using Vacancies.Db.Dto.Models.Languages;

namespace Vacancies.Db.Dto.Profiles.Languages
{
    public class LanguageSkillProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<LanguageSkill, DtoLanguageSkill>()
                .ForMember(
                    d => d.Language, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoLanguage>(s.Language)))
                .ForMember(
                    d => d.Level, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoLanguageLevel>(s.Level)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoLanguageSkill, LanguageSkill>()
                .ForMember(
                    d => d.Vacancy, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Level, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Language, 
                    o => o.Ignore());
        }
    }
}
