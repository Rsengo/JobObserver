using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Specializations;
using Resumes.Dto.Models.Specializations;

namespace Resumes.Dto.Profiles.Specializations
{
    public class ResumeSpecializationProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<ResumeSpecialization, DtoResumeSpecialization>()
                .ForMember(
                    d => d.Specialization,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSpecialization>(s.Specialization)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoResumeSpecialization, ResumeSpecialization>()
                .ForMember(
                    d => d.Resume, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Specialization, 
                    o => o.Ignore());
        }
    }
}
