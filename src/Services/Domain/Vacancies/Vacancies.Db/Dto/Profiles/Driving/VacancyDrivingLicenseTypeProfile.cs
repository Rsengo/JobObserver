using System;
using System.Collections.Generic;
using System.Text;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Driving;
using Vacancies.Db.Dto.Models.Driving;

namespace Vacancies.Db.Dto.Profiles.Driving
{
    public class VacancyDrivingLicenseTypeProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<VacancyDrivingLicenseType, DtoVacancyDrivingLicenseType>()
                .ForMember(
                    d => d.DrivingLicenseType, 
                    o => o.MapFrom(
                        s => s.DrivingLicenseType));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoVacancyDrivingLicenseType, VacancyDrivingLicenseType>()
                .ForMember(
                    d => d.Vacancy, 
                    o => o.Ignore())
                .ForMember(
                    d => d.DrivingLicenseType, 
                    o => o.Ignore());
        }
    }
}
