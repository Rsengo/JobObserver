using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Educations;
using Resumes.Dto.Models.Educations;
using Resumes.Dto.Models.Specializations;

namespace Resumes.Dto.Profiles.Educations
{
    public class EducationSpecializationProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<EducationSpecialization, DtoEducationSpecialization>()
                .ForMember(
                    d => d.Specialization,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSpecialization>(s.Specialization)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEducationSpecialization, EducationSpecialization>()
                .ForMember(
                    d => d.Education,
                    o => o.Ignore())
                .ForMember(
                    d => d.Specialization,
                    o => o.Ignore());
        }
    }
}
