using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Skills;
using Dictionaries.Db.Dto.Models.Skills;

namespace Dictionaries.Db.Dto.Profiles.Skills
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
