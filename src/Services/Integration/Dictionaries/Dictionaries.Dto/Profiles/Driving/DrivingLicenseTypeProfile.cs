using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Dictionaries.Db.Models.Driving;
using Dictionaries.Dto.Models.Driving;

namespace Dictionaries.Dto.Profiles.Driving
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
