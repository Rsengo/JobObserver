﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Languages;
using Dictionaries.Db.Dto.Models.Languages;

namespace Dictionaries.Db.Dto.Profiles.Languages
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
