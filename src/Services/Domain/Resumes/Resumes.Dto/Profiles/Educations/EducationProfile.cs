using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Educations;
using Resumes.Dto.Models.Educations;

namespace Resumes.Dto.Profiles.Educations
{
    public class EducationProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Education, DtoEducation>()
                .ForMember(
                    d => d.EducationalLevel, 
                    o => o.MapFrom(
                        s => s.EducationalLevel))
                .ForMember(
                    d => d.Specializations,
                    o => o.MapFrom(
                        s => s.Specializations.Select(x => x.Specialization)));
        }

        public override void Dto2Entity()
        {
            CreateMap<Education, DtoEducation>()
                .ForMember(
                    d => d.EducationalLevel,
                    o => o.Ignore())
                .ForMember(
                    d => d.Specializations,
                    o => o.Ignore());
        }
    }
}
