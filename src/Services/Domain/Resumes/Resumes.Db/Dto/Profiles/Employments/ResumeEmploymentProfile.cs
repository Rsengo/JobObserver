using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Employments;
using Resumes.Db.Dto.Models.Employments;

namespace Resumes.Db.Dto.Profiles.Employments
{
    public class ResumeEmploymentProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<ResumeEmployment, DtoResumeEmployment>()
                .ForMember(
                    d => d.Employment, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoResumeEmployment>(s.Employment)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoResumeEmployment, ResumeEmployment>()
                .ForMember(
                    d => d.Resume,
                    o => o.Ignore())
                .ForMember(
                    d => d.Employment,
                    o => o.Ignore());
        }
    }
}
