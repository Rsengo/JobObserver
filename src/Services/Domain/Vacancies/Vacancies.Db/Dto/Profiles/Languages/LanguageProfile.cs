﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Languages;
using Vacancies.Db.Dto.Models.Languages;

namespace Vacancies.Db.Dto.Profiles.Languages
{
    public class LanguageProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<Language, DtoLanguage>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoLanguage, Language>();
        }
    }
}
