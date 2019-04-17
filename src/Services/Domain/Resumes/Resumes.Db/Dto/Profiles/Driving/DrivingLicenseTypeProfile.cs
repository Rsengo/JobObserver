using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Driving;
using Resumes.Db.Dto.Models.Driving;

namespace Resumes.Db.Dto.Profiles.Driving
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
