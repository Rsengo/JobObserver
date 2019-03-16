using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Skills;
using Resumes.Dto.Models.Skills;

namespace Resumes.Dto.Profiles.Skills
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
