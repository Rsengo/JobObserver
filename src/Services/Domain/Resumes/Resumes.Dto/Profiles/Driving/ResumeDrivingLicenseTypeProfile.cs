using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Resumes.Db.Models.Driving;
using Resumes.Dto.Models.Driving;

namespace Resumes.Dto.Profiles.Driving
{
    public class ResumeDrivingLicenseTypeProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<ResumeDrivingLicenseType, DtoResumeDrivingLicenseType>()
                .ForMember(
                    d => d.DrivingLicenseType, 
                    o => o.MapFrom(
                        s => s.DrivingLicenseType));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoResumeDrivingLicenseType, ResumeDrivingLicenseType>()
                .ForMember(
                    d => d.Resume, 
                    o => o.Ignore())
                .ForMember(
                    d => d.DrivingLicenseType, 
                    o => o.Ignore());
        }
    }
}
