using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Experiences;
using Resumes.Dto.Models.Experiences;
using Resumes.Dto.Models.Industries;
using Resumes.Dto.Models.Specializations;

namespace Resumes.Dto.Profiles.Experiences
{
    public class ExperienceProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Experience, DtoExperience>()
                .ForMember(
                    d => d.Specialization, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSpecialization>(s.Specialization)))
                .ForMember(
                    d => d.Industry, 
                    o => o.MapFrom(
                        s => Mapper.Map<DtoIndustry>(s.Industry)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoExperience, Experience>()
                .ForMember(
                    d => d.Resume, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Industry, 
                    o => o.Ignore());
        }
    }
}
