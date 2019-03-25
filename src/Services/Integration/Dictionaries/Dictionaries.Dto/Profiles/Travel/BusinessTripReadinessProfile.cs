﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Travel;
using Dictionaries.Dto.Models.Travel;

namespace Dictionaries.Dto.Profiles.Travel
{
    public class BusinessTripReadinessProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<BusinessTripReadiness, DtoBusinessTripReadiness>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoBusinessTripReadiness, BusinessTripReadiness>();
        }
    }
}
