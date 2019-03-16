﻿using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Driving;
using Vacancies.Dto.Models.Driving;

namespace Vacancies.Dto.Profiles.Driving
{
    public class DrivingLicenseTypeProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<DrivingLicenseType, DtoDrivingLicenseType>();
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoDrivingLicenseType, DrivingLicenseType>();
        }
    }
}
