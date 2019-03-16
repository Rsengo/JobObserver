using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BuildingBlocks.AutoMapper;
using Vacancies.Db.Models.Negotiations;
using Vacancies.Dto.Models.Negotiations;

namespace Vacancies.Dto.Profiles.Negotiations
{
    public class VacancyNegotiationProfile : EntityDtoProfile
    {
        public override void Entity2Dto()
        {
            CreateMap<VacancyNegotiation, DtoVacancyNegotiation>()
                .ForMember(
                    d => d.Response,
                    o => o.MapFrom(
                        s => Mapper.Map<DtoResponse>(s.Response)));
        }

        public override void Dto2Entity()
        {
            CreateMap<DtoVacancyNegotiation, VacancyNegotiation>()
                .ForMember(
                    d => d.Vacancy,
                    o => o.Ignore())
                .ForMember(
                    d => d.Response,
                    o => o.Ignore());
        }
    }
}
