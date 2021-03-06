﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Languages;
using Dictionaries.Db.Dto.Models.Languages;

namespace Dictionaries.Db.Dto.Profiles.Languages
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
