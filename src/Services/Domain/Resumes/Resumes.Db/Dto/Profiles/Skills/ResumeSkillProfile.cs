using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Skills;
using Resumes.Db.Dto.Models.Skills;

namespace Resumes.Db.Dto.Profiles.Skills
{
    public class ResumeSkillProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<ResumeSkill, DtoResumeSkill>()
                .ForMember(
                    d => d.Skill,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSkill>(s.Skill)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoResumeSkill, ResumeSkill>()
                .ForMember(
                    d => d.Resume, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Skill, 
                    o => o.Ignore());
        }
    }
}
