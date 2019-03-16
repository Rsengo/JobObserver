using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Languages;
using Vacancies.Dto.Models.Languages;

namespace Vacancies.Dto.Profiles.Languages
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
