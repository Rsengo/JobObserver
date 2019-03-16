using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Educations;
using Resumes.Dto.Models.Educations;

namespace Resumes.Dto.Profiles.Educations
{
    public class EducationLevelProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<EducationalLevel, DtoEducationalLevel>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoEducationalLevel, EducationalLevel>();
        }
    }
}
