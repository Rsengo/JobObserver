﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Languages;
using Resumes.Db.Dto.Models.Languages;

namespace Resumes.Db.Dto.Profiles.Languages
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
