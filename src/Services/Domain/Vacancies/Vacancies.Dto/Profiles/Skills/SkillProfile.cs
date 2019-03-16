﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Skills;
using Vacancies.Dto.Models.Skills;

namespace Vacancies.Dto.Profiles.Skills
{
    public class SkillProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Skill, DtoSkill>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoSkill, Skill>();
        }
    }
}
