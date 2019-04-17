using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Skills;
using Vacancies.Db.Dto.Models.Skills;

namespace Vacancies.Db.Dto.Profiles.Skills
{
    public class VacancySkillProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<VacancySkill, DtoVacancySkill>()
                .ForMember(
                    d => d.Skill,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSkill>(s.Skill)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoVacancySkill, VacancySkill>()
                .ForMember(
                    d => d.Vacancy, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Skill, 
                    o => o.Ignore());
        }
    }
}
