using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Languages;
using Resumes.Dto.Models.Languages;

namespace Resumes.Dto.Profiles.Languages
{
    public class LanguageLevelProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<LanguageLevel, DtoLanguageLevel>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoLanguageLevel, LanguageLevel>();
        }
    }
}
