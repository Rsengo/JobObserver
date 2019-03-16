using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Languages;
using Resumes.Dto.Models.Languages;

namespace Resumes.Dto.Profiles.Languages
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
                    d => d.Resume, 
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
