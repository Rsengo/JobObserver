using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Specializations;
using Vacancies.Dto.Models.Specializations;

namespace Vacancies.Dto.Profiles.Specializations
{
    public class VacancySpecializationProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<VacancySpecialization, DtoVacancySpecialization>()
                .ForMember(
                    d => d.Specialization,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoSpecialization>(s.Specialization)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoVacancySpecialization, VacancySpecialization>()
                .ForMember(
                    d => d.Vacancy, 
                    o => o.Ignore())
                .ForMember(
                    d => d.Specialization, 
                    o => o.Ignore());
        }
    }
}
