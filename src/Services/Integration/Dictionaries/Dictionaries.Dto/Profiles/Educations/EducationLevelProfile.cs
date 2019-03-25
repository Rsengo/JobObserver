using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Educations;
using Dictionaries.Dto.Models.Educations;

namespace Dictionaries.Dto.Profiles.Educations
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
